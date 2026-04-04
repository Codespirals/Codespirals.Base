using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Codespirals.Base.Attributes;

/// <summary>
/// A service to be used in other classes through Dependency Injection
/// </summary>
/// <param name="serviceInterface">The type of the interface the service is implementing</param>
/// <param name="defaultLifetime">The service lifetime according to <see cref="ServiceLifetime"/></param>
/// <param name="optionType">The type of the option DTO</param>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableService(Type serviceInterface, ServiceLifetime defaultLifetime = ServiceLifetime.Scoped, Type? optionType = default) : Attribute
{
    /// <summary>
    /// 
    /// </summary>
    public Type ServiceInterface { get; internal set; } = serviceInterface;
    /// <summary>
    /// 
    /// </summary>
    public ServiceLifetime DefaultLifetime { get; internal set; } = defaultLifetime;
    /// <summary>
    /// 
    /// </summary>
    public Type? OptionType { get; internal set; } = optionType is null ? optionType
        : optionType.GetCustomAttribute<ServiceOptions>() is not null ? optionType
        : throw new Exception($"{nameof(optionType)} must have the {nameof(ServiceOptions)} attribute.");
}