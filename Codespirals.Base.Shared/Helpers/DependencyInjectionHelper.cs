using Microsoft.Extensions.Configuration;
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
    public static void EnsureRequiredSettingsAreSet(Type serviceType, IConfiguration configuration, string? key = null)
    {
        var requiredSettingAttributes = serviceType.GetCustomAttributes<RequiredConfigurationSetting>();
        if (requiredSettingAttributes is null)
            return;
        foreach (var attribute in requiredSettingAttributes)
        {
            var settingsPathPrefix = string.IsNullOrWhiteSpace(key) ? nameof(serviceType) : key;
            var fullSettingsPath = $"{settingsPathPrefix}__{attribute.SettingPath.Replace(",", "__").Replace(":", "__").Replace(";", "__")}";
            if (string.IsNullOrWhiteSpace(configuration[fullSettingsPath]))
                throw new Exception($"No configuration found for setting: {attribute.SettingPath}");
        }
    }
}
