namespace Codespirals.Base;

/// <summary>
/// A selection of entity statuses for databases
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface IEntityStatuses<TSelf> : IIsEnum<TSelf>
    where TSelf : IEntityStatuses<TSelf>
{
    /// <summary>
    /// Indicates no status has been set
    /// </summary>
    public static abstract TSelf Unset { get; }
    /// <summary>
    /// Indicates an item has been deleted
    /// </summary>
    public static abstract TSelf Deleted { get; }
}
