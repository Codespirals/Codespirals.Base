namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableDatabase : Attribute
{

}
