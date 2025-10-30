using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Codespirals.Base;
public static class DependencyInjectionHelper
{
    public static void EnsureRequiredEnvironmentalVariablesAreSet(Type serviceType)
    {
        var requiredEnvironmentalVariableAttributes = serviceType.GetCustomAttributes<RequiredEnvironmentalVariable>();
        if (requiredEnvironmentalVariableAttributes is null)
            return;
        _ = requiredEnvironmentalVariableAttributes.Select(a => a.Variable).Select(v => Environment.GetEnvironmentVariable(v) ?? throw new Exception($"Missing environmental variable: {v}."));
    }
    public static void EnsureRequiredSettingsAreSet(Type serviceType, IConfiguration configuration)
    {
        var requiredSettingAttributes = serviceType.GetCustomAttributes<RequiredConfigurationSetting>();
        if (requiredSettingAttributes is null)
            return;
        foreach (var attribute in requiredSettingAttributes)
        {
            if (string.IsNullOrWhiteSpace(configuration[attribute.SettingPath.Replace(",", "__").Replace(":", "__").Replace(";", "__")]))
                throw new Exception($"No configuration found for setting: {attribute.SettingPath}");
        }
    }
}
