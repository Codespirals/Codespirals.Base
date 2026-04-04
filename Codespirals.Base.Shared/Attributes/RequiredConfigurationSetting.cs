namespace Codespirals.Base.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredConfigurationSetting(string settingPath) : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public string SettingPath { get; internal set; } = settingPath;
}
