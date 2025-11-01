using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Codespirals.Base;
public static class ConfigurationExtensions
{
    public static IConfiguration GetServiceConfigurations(this IConfiguration configuration)
    {
        var serviceOptions = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()
            .Where(t => !t.IsAbstract && t.GetCustomAttribute<ServiceOptions>() is not null));

        foreach (var serviceOption in serviceOptions)
        {
            var attribute = serviceOption.GetCustomAttribute<ServiceOptions>()!;
            var key = attribute.Key ?? nameof(attribute.Service);
        }

        return configuration;
    }
}
