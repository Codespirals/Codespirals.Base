using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Codespirals.Base.Attributes;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = true,
    Inherited = true)]
public sealed class RequiredInjectableService(Type service, ServiceLifetime lifetime = ServiceLifetime.Scoped, string? key = null) : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public Type Service { get; internal set; } = service.GetCustomAttributes<InjectableService>().Any() ? service : throw new Exception($"Service {service?.Name ?? "[Name not found]"} does not implement the attribute {nameof(InjectableService)}.");
    /// <summary>
    /// 
    /// </summary>
    public ServiceLifetime? Lifetime { get; internal set; } = lifetime;
    /// <summary>
    /// 
    /// </summary>
    public string? Key { get; internal set; } = key;
}
