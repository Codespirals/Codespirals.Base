namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredEnvironmentalVariable : Attribute
{
    public string VariableName { get; internal set; }

    public RequiredEnvironmentalVariable(string variableName, bool throwExceptionOnBuildIfUnset = true)
    {
        if (throwExceptionOnBuildIfUnset)
            _ = Environment.GetEnvironmentVariable(variableName) ?? throw new Exception($"Required environmental variable {variableName} is not set.");

        VariableName = variableName;
    }
}
