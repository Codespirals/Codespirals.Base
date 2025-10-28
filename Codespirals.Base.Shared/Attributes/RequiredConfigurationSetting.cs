namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredConfigurationSetting(string settingName, string sectionName = "") : Attribute
{
    public string Section { get; internal set; } = sectionName;
    public string Setting { get; internal set; } = settingName;
}
