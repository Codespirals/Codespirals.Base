using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Codespirals.Base;
public static class DependencyInjectionHelper
{
    public static void CheckRequiredEnvironmentalVariables(Type serviceType)
    {
        var attributes = serviceType.GetCustomAttributes<RequiredEnvironmentalVariable>();
        if (attributes is null)
            return;
        _ = attributes.Select(a => a.Variable).Select(v => Environment.GetEnvironmentVariable(v) ?? throw new Exception($"Missing environmental variable: {v}."));
    }
    public static void CheckRequiredSettingsExist(Type serviceType, IConfigurationRoot configuration)
    {
        var attributes = serviceType.GetCustomAttributes<RequiredConfigurationSetting>();
        if (attributes is null)
            return;
        foreach (var attribute in attributes)
        {
            if (string.IsNullOrWhiteSpace(attribute.Section))
            {
                var settings = configuration.GetChildren();
                if (!settings.Any())
                    throw new Exception($"No configuration found");
                _ = settings.FirstOrDefault(c => c.Key == attribute.Setting) ?? throw new Exception($"Required setting {attribute.Setting} not found.");
            }
            else
            {
                var section = configuration.GetSection(attribute.Section);
                if (!section.GetChildren().Any())
                    throw new Exception($"Configuration section [{attribute.Section}] required but not found");
                _ = section.GetChildren().FirstOrDefault(c => c.Key == attribute.Setting) ?? throw new Exception($"Required setting {attribute.Section}:{attribute.Setting} not found.");
            }
        }
    }
}
