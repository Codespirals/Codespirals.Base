using System.Reflection;

namespace Codespirals.Base.Attributes;

[AttributeUsage(AttributeTargets.Class,
    AllowMultiple = false,
    Inherited = true)]
public sealed class InjectableDatabase(Type optionType) : Attribute
{
    public Type? OptionType { get; internal set; } = optionType.GetCustomAttribute<DatabaseOptions>() is not null
        ? optionType
        : throw new Exception($"{nameof(optionType)} must have the {nameof(DatabaseOptions)} attribute.");
}
