using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Codespirals.Base;
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Dynamically adds ALL custom services that implement <see cref="InjectableService"/> of the application to the service collection
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAllAttributedServices(this IServiceCollection services, IConfiguration? configuration = null)
    {
        var injectableServices = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()
            .Where(t => !t.IsAbstract && t.GetCustomAttribute<InjectableService>() is not null));

        foreach (var injectableService in injectableServices)
        {
            var attribute = injectableService.GetCustomAttribute<InjectableService>();
            if (attribute is null)
                continue;
            services.TryAddAttributedService(injectableService, attribute.DefaultKey, configuration);
        }
        return services;
    }

    /// <summary>
    /// Add a custom service to the service collection
    /// </summary>
    /// <param name="services"></param>
    /// <param name="attributedServiceType">The type of the service. To be able to add a service through this method, it must have the <see cref="InjectableService"/> Attribute</param>
    /// <param name="configuration">The KeyValue dictionary containing all settings pertaining to the service</param>
    /// <param name="key">An optional key for <see cref="KeyedService"/> - setting this parameter overrides any <see cref="InjectableService.DefaultKey"/></param>
    public static void TryAddAttributedService(this IServiceCollection services, Type attributedServiceType, string? key = null, IConfiguration? configuration = null)
    {
        // make sure it has the InjectableService attribute
        var serviceAttribute = attributedServiceType.GetCustomAttribute<InjectableService>()!;
        if (serviceAttribute is null)
            return;

        /// if no key is given, try to overwrite with the default key (if one exists)
        key ??= serviceAttribute.DefaultKey;

        /// if the service requires a key and none is provided, it's added by <see cref="AddRequiredSubServices(IServiceCollection, Type, IConfiguration?)"/>
        /// this allows us to dynamically add the same service multiple times
        if (serviceAttribute.MustBeKeyed is true && key is null)
            throw new Exception($"Service of type {nameof(attributedServiceType)} requires a key set, but none was provided.");

        // check if service is already added
        if (services.GetService(attributedServiceType, key) is not null)
            return;

        if (configuration is not null && serviceAttribute.OptionType is not null)
        {
            services.AddGenericOptions(serviceAttribute.OptionType, configuration);
            EnsureRequiredSettingsAreSet(attributedServiceType, configuration, key);
        }

        services.AddRequiredSubServices(attributedServiceType);

        if (key is null)
            services.TryAdd(new ServiceDescriptor(serviceAttribute.ServiceInterface, attributedServiceType, serviceAttribute.Lifetime));
        else
        {
            switch (serviceAttribute.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.TryAddKeyedSingleton(serviceAttribute.ServiceInterface, key, attributedServiceType);
                    break;
                case ServiceLifetime.Scoped:
                    services.TryAddKeyedScoped(serviceAttribute.ServiceInterface, key, attributedServiceType);
                    break;
                case ServiceLifetime.Transient:
                    services.TryAddKeyedTransient(serviceAttribute.ServiceInterface, key, attributedServiceType);
                    break;
                default:
                    services.TryAddKeyedScoped(serviceAttribute.ServiceInterface, key, attributedServiceType);
                    break;
            }
        }
    }
    internal static void AddRequiredSubServices(this IServiceCollection services, Type serviceType, IConfiguration? configuration = null)
    {
        var requiredSubServices = serviceType.GetCustomAttributes<RequiredInjectableService>();
        if (requiredSubServices is null)
            return;

        foreach (var requiredService in requiredSubServices)
        {
            services.TryAddAttributedService(requiredService.Service, requiredService.Key, configuration);
        }
    }

    internal static ServiceDescriptor? GetService(this IServiceCollection services, Type serviceType, string? key = null)
        => key is null
                ? services.FirstOrDefault(s => s.ServiceType == serviceType)
                : services.FirstOrDefault(s => s.ServiceType == serviceType && s.ServiceKey?.ToString() == key);

    internal static void AddGenericOptions(this IServiceCollection services, Type optionType, IConfiguration configuration)
    {
        var addOptionMethod = typeof(OptionsConfigurationServiceCollectionExtensions)
              .GetMethods(BindingFlags.Static | BindingFlags.Public)
              .Where(x => x.Name == nameof(OptionsConfigurationServiceCollectionExtensions.Configure)
              && x.IsGenericMethodDefinition
              && x.GetGenericArguments().Length == 1
              && x.GetParameters().Length == 2)
              .Single();

        _ = addOptionMethod.MakeGenericMethod(optionType).Invoke(null, [services, configuration]);
    }

    internal static void EnsureRequiredSettingsAreSet(Type serviceType, IConfiguration configuration, string? key = null)
    {
        var requiredSettingAttributes = serviceType.GetCustomAttributes<RequiredConfigurationSetting>();
        if (requiredSettingAttributes is null)
            return;
        foreach (var attribute in requiredSettingAttributes)
        {
            var settingsPathPrefix = string.IsNullOrWhiteSpace(key) ? nameof(serviceType) : key;
            var fullSettingsPath = $"{settingsPathPrefix}__{attribute.SettingPath.Replace(",", "__").Replace(":", "__").Replace(";", "__")}";
            if (!string.IsNullOrWhiteSpace(configuration[fullSettingsPath]))
                continue;

            throw new Exception($"No configuration found for setting: {attribute.SettingPath}");
        }
    }
}
