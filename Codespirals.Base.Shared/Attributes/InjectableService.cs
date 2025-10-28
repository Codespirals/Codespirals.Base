using Microsoft.Extensions.DependencyInjection;

namespace Codespirals.Base;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableService(ServiceLifetime lifetime = ServiceLifetime.Scoped, string? key = null, Type? optionsType = null) : Attribute
{
    public ServiceLifetime Lifetime { get; internal set; } = lifetime;
    public string? Key { get; internal set; } = key;
    public Type? OptionsType { get; internal set; }= optionsType;
}