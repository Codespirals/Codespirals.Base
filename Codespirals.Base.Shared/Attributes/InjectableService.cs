using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Codespirals.Base;

/// <summary>
/// A service to be used in other classes through Dependency Injection
/// </summary>
/// <param name="serviceInterface">The type of the interface the service is implementing</param>
/// <param name="lifetime">The service lifetime according to <see cref="ServiceLifetime"/></param>
/// <param name="mustBeKeyed">If the service must be a keyed service type - <see langword="null"/> if ambiguous</param>
/// <param name="defaultKey">A service key. If <see cref="mustBeKeyed"/> is <see langword="true"/> this should be set.</param>
/// <param name="optionType">The type of the option DTO</param>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableService(Type serviceInterface, ServiceLifetime lifetime = ServiceLifetime.Scoped, bool? mustBeKeyed = null, string? defaultKey = null, Type? optionType = default) : Attribute
{
    public Type ServiceInterface { get; internal set; } = serviceInterface;
    public ServiceLifetime Lifetime { get; internal set; } = lifetime;
    public bool? MustBeKeyed { get; internal set; } = mustBeKeyed;
    public string? DefaultKey { get; internal set; } = defaultKey;
    public Type? OptionType { get; internal set; } = optionType is null ? optionType 
        : optionType.GetCustomAttribute<ServiceOptions>() is not null ? optionType 
        : throw new Exception($"{nameof(optionType)} must have the {nameof(ServiceOptions)} attribute.");
}