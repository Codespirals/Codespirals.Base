namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredEnvironmentalVariable(string variableName, bool throwExceptionIfUnset = false) : Attribute
{
    public string VariableName { get; internal set; } = variableName;
    public bool ThrowIfUnset { get; internal set; } = throwExceptionIfUnset;
}
