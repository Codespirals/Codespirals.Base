using System.Reflection;

namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public class RequiredInjectableService(Type service, string? key = null) : Attribute
{
    public Type Service { get; internal set; } = service.GetCustomAttributes<InjectableService>().Any() ? service : throw new Exception($"Service {service?.Name ?? "[Name not found]"} does not implement the attribute {nameof(InjectableService)}.");
    public string? Key { get; internal set; } = key;
}
