namespace Codespirals.Base.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredEnvironmentalVariable : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public string VariableName { get; internal set; }
    /// <summary>
    /// 
    /// </summary>
    public RequiredEnvironmentalVariable(string variableName, bool throwExceptionOnBuildIfUnset = true)
    {
        if (throwExceptionOnBuildIfUnset)
            _ = Environment.GetEnvironmentVariable(variableName) ?? throw new Exception($"Required environmental variable {variableName} is not set.");

        VariableName = variableName;
    }
}
