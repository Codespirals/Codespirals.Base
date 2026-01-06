namespace Codespirals.Base.Attributes;

/// <summary>
/// This Attributes indicates that the attached class is an options DTO for the given <paramref name="service"/> type
/// </summary>
/// <param name="service"></param>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = false)]
public sealed class ServiceOptions(Type service) : Attribute
{
    /// <summary>
    /// The service type these options are for
    /// </summary>
    public Type Service { get; internal set; } = service;
}
