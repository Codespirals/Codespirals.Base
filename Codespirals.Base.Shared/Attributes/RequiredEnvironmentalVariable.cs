namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredEnvironmentalVariable(string variableName) : Attribute
{
    public string Variable { get; internal set; } = variableName;
}
