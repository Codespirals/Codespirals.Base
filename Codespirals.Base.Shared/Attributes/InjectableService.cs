using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Codespirals.Base;

/// <summary>
/// A service to be used in other classes through Dependency Injection
/// </summary>
/// <param name="serviceInterface">The type of the interface the service is implementing</param>
/// <param name="lifetime">The service lifetime according to <see cref="ServiceLifetime"/></param>
/// <param name="isKeyed">If the service requires to be keyed (Set this to true if you want a service to be able to be duplicated)</param>
/// <param name="optionType">The type of the option DTO</param>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableService(Type serviceInterface, ServiceLifetime lifetime = ServiceLifetime.Scoped, bool isKeyed = false, Type? optionType = default) : Attribute
{
    public Type ServiceInterface { get; internal set; } = serviceInterface;
    public ServiceLifetime Lifetime { get; internal set; } = lifetime;
    public bool IsKeyed { get; internal set; } = isKeyed;
    public Type? OptionType { get; internal set; } = optionType is null ? optionType 
        : optionType.GetCustomAttribute<ServiceOptions>() is not null ? optionType 
        : throw new Exception($"{nameof(optionType)} must have the {nameof(ServiceOptions)} attribute.");
}