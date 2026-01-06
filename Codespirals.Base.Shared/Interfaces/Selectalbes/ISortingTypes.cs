namespace Codespirals.Base;

/// <summary>
/// A selection of options a list can be sorted by
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface ISortingTypes<TSelf> : IIsEnum<TSelf>
    where TSelf : ISortingTypes<TSelf>
{
    /// <summary>
    /// No sorting being applied
    /// </summary>
    static abstract TSelf Unsorted { get; }
}
