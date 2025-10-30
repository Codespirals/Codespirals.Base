using System.Reflection;

namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public class RequiredInjectableService<TService>(TService service, string? key = null) : Attribute
{
    public TService Service { get; internal set; } = typeof(TService).GetCustomAttributes<InjectableService>().Any() ? service : throw new Exception($"Service {service?.GetType().Name ?? "[Name not found]"} does not implement the attribute {nameof(InjectableService)}.");
    public string? Key { get; internal set; } = key;
}
