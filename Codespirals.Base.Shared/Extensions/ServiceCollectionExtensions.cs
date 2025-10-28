using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Codespirals.Base;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => !t.IsAbstract && t.GetCustomAttribute<InjectableService>() is not null);

        foreach (var type in types)
        {
            DependencyInjectionHelper.CheckRequiredEnvironmentalVariables(type);

            var attribute = type.GetCustomAttribute<InjectableService>()!;
            if (attribute is null)
                continue;

            foreach (var serviceInterface in type.GetInterfaces())
            {
                if (attribute.Key is null)
                    services.TryAdd(new ServiceDescriptor(serviceInterface, type, attribute.Lifetime));
                else
                {
                    switch (attribute.Lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.TryAddKeyedSingleton(serviceInterface, attribute.Key, type);
                            break;
                        case ServiceLifetime.Scoped:
                            services.TryAddKeyedScoped(serviceInterface, attribute.Key, type);
                            break;
                        case ServiceLifetime.Transient:
                            services.TryAddKeyedTransient(serviceInterface, attribute.Key, type);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        return services;
    }
}
