namespace Codespirals.Base;

/// <summary>
/// This Attributes indicates that the attached class is an IOptions<> DTO for the given <see cref="service"/> type
/// </summary>
/// <param name="service"></param>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = false)]
public sealed class ServiceOptions(Type service) : Attribute
{
    public Type Service { get; internal set; } = service;
}
