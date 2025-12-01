using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Codespirals.Base.Attributes;
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Dynamically adds ALL custom services that implement <see cref="InjectableService"/> and are injected in another service with the <see cref="RequiredInjectableService"/> attribute
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAllAttributedServices(this IServiceCollection services, IConfiguration? configuration = null)
    {
        var serviceWithRequiredServices = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => 
        a.GetTypes().Where(t => !t.IsAbstract && t.GetCustomAttribute<RequiredInjectableService>() is not null));

        foreach (var service in serviceWithRequiredServices)
        {
            var attributes = service.GetCustomAttributes<RequiredInjectableService>();
            if (attributes is null || !attributes.Any())
                continue;
            foreach (var attribute in attributes)
            {
                services.TryAddAttributedService(attribute.Service, attribute.Lifetime, attribute.Key, configuration: configuration);
            }
        }
        return services;
    }

    /// <summary>
    /// Add a custom service to the service collection
    /// </summary>
    /// <param name="services"></param>
    /// <param name="attributedServiceType">The type of the service. To be able to add a service through this method, it must have the <see cref="InjectableService"/> Attribute</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service</param>
    /// <param name="configuration">The KeyValue dictionary containing all settings pertaining to the service</param>
    /// <param name="key">An optional key for <see cref="KeyedService"/> - setting this parameter overrides any <see cref="InjectableService.DefaultKey"/></param>
    public static void TryAddAttributedService(this IServiceCollection services, Type attributedServiceType, ServiceLifetime? lifetime = null, string? key = null, IConfiguration? configuration = null)
    {
        // make sure it has the InjectableService attribute
        var serviceAttribute = attributedServiceType.GetCustomAttribute<InjectableService>()!;
        if (serviceAttribute is null)
            return;

        // check if service is already added
        if (services.GetService(attributedServiceType, key) is not null)
            return;

        // make sure configs are OK
        if (configuration is not null && serviceAttribute.OptionType is not null)
        {
            services.AddGenericOptions(serviceAttribute.OptionType, configuration);
            EnsureRequiredSettingsAreSet(attributedServiceType, configuration, key);
        }

        lifetime ??= serviceAttribute.DefaultLifetime;
        if (key is null)
            services.TryAdd(new ServiceDescriptor(serviceAttribute.ServiceInterface, attributedServiceType, lifetime));
        else
        {
            switch (lifetime)
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
