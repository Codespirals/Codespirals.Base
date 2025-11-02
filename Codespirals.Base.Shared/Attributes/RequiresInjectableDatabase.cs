namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiresInjectableDatabase(Type context) : Attribute
{
    public Type Context { get; internal set; } = context;
}
