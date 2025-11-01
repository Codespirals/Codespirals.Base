namespace Codespirals.Base;

/// <summary>
/// This Attributes indicates that the attached class is an IOptions<> DTO for the given <see cref="service"/> type
/// </summary>
/// <param name="service"></param>
/// <param name="key"></param>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = false)]
internal sealed class ServiceOptions(Type service, string? key = null) : Attribute
{
    public Type Service { get; internal set; } = service;
    public string Key { get; internal set; } = key ?? nameof(service);
}
