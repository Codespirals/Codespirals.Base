namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredEnvironmentalVariable(string variableName) : Attribute
{
    public string Variable { get; internal set; } = variableName;
}
