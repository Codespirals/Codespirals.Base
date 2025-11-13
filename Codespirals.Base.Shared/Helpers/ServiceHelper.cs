using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Codespirals.Base;
public static class ServiceHelper
{
    public static Result EnsureRequiredEnvironmentalVariablesAreSet(Type serviceType)
    {
        var requiredEnvironmentalVariableAttributes = serviceType.GetCustomAttributes<RequiredEnvironmentalVariable>();
        if (requiredEnvironmentalVariableAttributes is null)
            return Result.Ok();
        foreach (var attribute in requiredEnvironmentalVariableAttributes)
        {
            var v = Environment.GetEnvironmentVariable(attribute.VariableName);
            if (!string.IsNullOrWhiteSpace(v))
                continue;
            if (attribute.ThrowIfUnset)
                throw new Exception($"No configuration found for setting: {attribute.VariableName}");
            else
                return Result.Fail($"Setting {nameof(attribute.VariableName)} is not properly set.");
        }
        return Result.Ok();
    }
    public static Result EnsureRequiredSettingsAreSet(Type serviceType, IConfiguration configuration, string? key = null)
    {
        var requiredSettingAttributes = serviceType.GetCustomAttributes<RequiredConfigurationSetting>();
        if (requiredSettingAttributes is null)
            return Result.Ok();
        foreach (var attribute in requiredSettingAttributes)
        {
            var settingsPathPrefix = string.IsNullOrWhiteSpace(key) ? nameof(serviceType) : key;
            var fullSettingsPath = $"{settingsPathPrefix}__{attribute.SettingPath.Replace(",", "__").Replace(":", "__").Replace(";", "__")}";
            if (!string.IsNullOrWhiteSpace(configuration[fullSettingsPath]))
                continue;
            if (attribute.ThrowIfUnset)
                throw new Exception($"No configuration found for setting: {attribute.SettingPath}");
            else
                return Result.Fail($"Setting {nameof(attribute.SettingPath)} is not properly set.");
        }
        return Result.Ok();
    }
}
