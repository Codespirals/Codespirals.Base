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
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration? configuration = null)
    {
        var injectableServices = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()
            .Where(t => !t.IsAbstract && t.GetCustomAttribute<InjectableService>() is not null));

        foreach (var injectableService in injectableServices)
        {
            services.TryAddCustomService(injectableService, configuration);
        }
        return services;
    }

    /// <summary>
    /// Add a custom service to the service collection
    /// </summary>
    /// <param name="services"></param>
    /// <param name="serviceType">The type of the service. To be able to add a service through this method, it must have the <see cref="InjectableService"/> Attribute</param>
    /// <param name="configuration">The KeyValue dictionary containing all settings pertaining to the service</param>
    /// <param name="key">An optional key for <see cref="KeyedService"/></param>
    public static void TryAddCustomService(this IServiceCollection services, Type serviceType, IConfiguration? configuration = null, string? key = null)
    {
        // make sure it has the InjectableService attribute
        var serviceAttribute = serviceType.GetCustomAttribute<InjectableService>()!;
        if (serviceAttribute is null)
            return;

        /// if the service requires a key and none is provided, it's added by <see cref="AddRequiredSubServices(IServiceCollection, Type, IConfiguration?)"/>
        /// this allows us to dynamically add the same service multiple times
        if (serviceAttribute.IsKeyed && key is null)
            return;

        // check if service is already added
        if (services.GetService(serviceType, key) is not null)
            return;

        DependencyInjectionHelper.EnsureRequiredEnvironmentalVariablesAreSet(serviceType);

        if (configuration is not null && serviceAttribute.OptionType is not null)
        {
            var addOptionMethod = typeof(OptionsConfigurationServiceCollectionExtensions)
              .GetMethods(BindingFlags.Static | BindingFlags.Public)
              .Where(x => x.Name == nameof(OptionsConfigurationServiceCollectionExtensions.Configure) 
              && x.IsGenericMethodDefinition 
              && x.GetGenericArguments().Length == 1
              && x.GetParameters().Length == 2)
              .Single();
            
            _ = addOptionMethod.MakeGenericMethod(serviceAttribute.OptionType).Invoke(null, [services, configuration]);
            DependencyInjectionHelper.EnsureRequiredSettingsAreSet(serviceType, configuration);
        }

        services.AddRequiredSubServices(serviceType);

        if (key is null)
            services.TryAdd(new ServiceDescriptor(serviceAttribute.ServiceInterface, serviceType, serviceAttribute.Lifetime));
        else
        {
            switch (serviceAttribute.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.TryAddKeyedSingleton(serviceAttribute.ServiceInterface, key, serviceType);
                    break;
                case ServiceLifetime.Scoped:
                    services.TryAddKeyedScoped(serviceAttribute.ServiceInterface, key, serviceType);
                    break;
                case ServiceLifetime.Transient:
                    services.TryAddKeyedTransient(serviceAttribute.ServiceInterface, key, serviceType);
                    break;
                default:
                    services.TryAddKeyedScoped(serviceAttribute.ServiceInterface, key, serviceType);
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
            // find service types implementing those interfaces
            var subServiceType = FindServiceImplementingInterface(requiredService.ServiceInterface);
            services.TryAddCustomService(subServiceType, configuration, requiredService.Key);
        }
    }

    internal static ServiceDescriptor? GetService(this IServiceCollection services, Type serviceType, string? key = null)
        => key is null
                ? services.FirstOrDefault(s => s.ServiceType == serviceType)
                : services.FirstOrDefault(s => s.ServiceType == serviceType && s.ServiceKey?.ToString() == key);

    internal static Type FindServiceImplementingInterface(Type serviceInterface)
       => AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => t.IsClass).FirstOrDefault(t => t.IsAssignableFrom(serviceInterface)) 
        ?? throw new Exception($"No type (service) is implementing [{nameof(serviceInterface)}]");
}
