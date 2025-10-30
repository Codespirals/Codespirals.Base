using Microsoft.Extensions.DependencyInjection;

namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableService(Type serviceInterface, ServiceLifetime lifetime = ServiceLifetime.Scoped, IOptionsBase? options = default) : Attribute
{
    public Type ServiceInterface { get; internal set; } = serviceInterface;
    public ServiceLifetime Lifetime { get; internal set; } = lifetime;
    public IOptionsBase? Options { get; internal set; } = options;
}