using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Codespirals.Base;
public static class DependencyInjectionHelper
{
    public static void EnsureRequiredEnvironmentalVariablesAreSet(Type serviceType)
    {
        var attributes = serviceType.GetCustomAttributes<RequiredEnvironmentalVariable>();
        if (attributes is null)
            return;
        _ = attributes.Select(a => a.Variable).Select(v => Environment.GetEnvironmentVariable(v) ?? throw new Exception($"Missing environmental variable: {v}."));
    }
    public static void EnsureRequiredSettingsAreSet(Type serviceType, IConfiguration configuration)
    {
        var attributes = serviceType.GetCustomAttributes<RequiredConfigurationSetting>();
        if (attributes is null)
            return;
        foreach (var attribute in attributes)
        {
            if (string.IsNullOrWhiteSpace(configuration[attribute.SettingPath.Replace(",", "__").Replace(":", "__").Replace(";", "__")]))
                throw new Exception($"No configuration found for setting: {attribute.SettingPath}");
        }
    }
}
