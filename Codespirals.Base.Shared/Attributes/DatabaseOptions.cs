namespace Codespirals.Base.Attributes;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = false)]
internal class DatabaseOptions(Type dbContext) : Attribute
{
    public Type DbContext { get; internal set; } = dbContext;
}
