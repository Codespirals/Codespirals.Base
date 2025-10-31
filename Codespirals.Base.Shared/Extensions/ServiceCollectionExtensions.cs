using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Codespirals.Base;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration? configuration = null)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => !t.IsAbstract && t.GetCustomAttribute<InjectableService>() is not null);

        foreach (var type in types)
        {
            DependencyInjectionHelper.EnsureRequiredEnvironmentalVariablesAreSet(type);
            if (configuration is not null)
                DependencyInjectionHelper.EnsureRequiredSettingsAreSet(type, configuration);

            services.TryAddCustomService(type);
        }
        return services;
    }
    internal static void TryAddCustomService(this IServiceCollection services, Type serviceType)
    {
        // make sure it has the InjectableService attribute
        var serviceAttribute = serviceType.GetCustomAttribute<InjectableService>()!;
        if (serviceAttribute is null)
            return;

        services.AddRequiredSubServices(serviceType);

        var key = serviceAttribute.OptionType is not null and IOptionsBase ? ((IOptionsBase)serviceAttribute.OptionType).ServiceKey : null;
        // check if service is already added
        if (services.GetService(serviceType, key) is not null)
            return;

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
    internal static void AddRequiredSubServices(this IServiceCollection services, Type serviceType)
    {
        var requiredServiceAttributes = serviceType.GetCustomAttributes<RequiredInjectableService>();
        if (requiredServiceAttributes is null)
            return;
        foreach (var requiredService in requiredServiceAttributes)
        {
            services.TryAddCustomService(requiredService.Service);
        }
    }
    internal static ServiceDescriptor? GetService(this IServiceCollection services, Type serviceType, string? key = null)
        => key is null
                ? services.FirstOrDefault(s => s.ServiceType == serviceType)
                : services.FirstOrDefault(s => s.ServiceType == serviceType && s.ServiceKey?.ToString() == key);

}
