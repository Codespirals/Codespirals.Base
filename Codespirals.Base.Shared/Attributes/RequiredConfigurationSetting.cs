namespace Codespirals.Base.Attributes;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredConfigurationSetting(string settingPath) : Attribute
{
    public string SettingPath { get; internal set; } = settingPath;
}
