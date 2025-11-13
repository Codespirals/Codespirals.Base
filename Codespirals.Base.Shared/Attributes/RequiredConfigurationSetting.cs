namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredConfigurationSetting(string settingPath, bool throwExceptionIfUnset = false) : Attribute
{
    public string SettingPath { get; internal set; } = settingPath;
    public bool ThrowIfUnset { get; internal set; } = throwExceptionIfUnset;
}
