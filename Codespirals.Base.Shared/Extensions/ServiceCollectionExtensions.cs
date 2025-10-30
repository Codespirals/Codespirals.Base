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
            var attribute = type.GetCustomAttribute<InjectableService>()!;
            if (attribute is null)
                continue;

            DependencyInjectionHelper.EnsureRequiredEnvironmentalVariablesAreSet(type);
            if (configuration is not null)
                DependencyInjectionHelper.EnsureRequiredSettingsAreSet(type, configuration);

            services.AddRequiredSubServices(type);

            services.TryAddCustomService(attribute.ServiceInterface, type, attribute.Lifetime, attribute.Options?.ServiceKey);
        }
        return services;
    }
    internal static void TryAddCustomService(this IServiceCollection services, Type serviceInterface, Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Scoped, string? key = null)
    {
        if (services.GetService(serviceType, key) is not null)
            return;
        if (key is null)
            services.TryAdd(new ServiceDescriptor(serviceInterface, serviceType, lifetime));
        else
        {
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.TryAddKeyedSingleton(serviceInterface, key, serviceType);
                    break;
                case ServiceLifetime.Scoped:
                    services.TryAddKeyedScoped(serviceInterface, key, serviceType);
                    break;
                case ServiceLifetime.Transient:
                    services.TryAddKeyedTransient(serviceInterface, key, serviceType);
                    break;
                default:
                    services.TryAddKeyedScoped(serviceInterface, key, serviceType);
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
            var serviceAttribute = requiredService.Service.GetCustomAttribute<InjectableService>();
            if (serviceAttribute is null)
                continue;
            services.TryAddCustomService(serviceAttribute.ServiceInterface,
                requiredService.Service,
                serviceAttribute?.Lifetime ?? ServiceLifetime.Scoped,
                serviceAttribute?.Options?.ServiceKey);
        }
    }
    internal static ServiceDescriptor? GetService(this IServiceCollection services, Type serviceType, string? key = null)
        => key is null
                ? services.FirstOrDefault(s => s.ServiceType == serviceType)
                : services.FirstOrDefault(s => s.ServiceType == serviceType && s.ServiceKey?.ToString() == key);

}
