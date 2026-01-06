using System.Reflection;

namespace Codespirals.Base.Attributes;

/// <summary>
/// A database to be injected via Dependency injection
/// </summary>
/// <param name="optionType"></param>
[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableDatabase(Type optionType) : Attribute
{
    /// <summary>
    /// The class of the options
    /// </summary>
    public Type? OptionType { get; internal set; } = optionType.GetCustomAttribute<DatabaseOptions>() is not null
        ? optionType
        : throw new Exception($"{nameof(optionType)} must have the {nameof(DatabaseOptions)} attribute.");
}
