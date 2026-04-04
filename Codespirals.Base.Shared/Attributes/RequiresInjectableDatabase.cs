namespace Codespirals.Base.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiresInjectableDatabase(Type context) : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public Type Context { get; internal set; } = context;
}
