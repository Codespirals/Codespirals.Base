namespace Codespirals.Base;

public interface IEntityStatuses<TValue> : IIsEnum<TValue>
    where TValue : IEntityStatuses<TValue>
{
    public static abstract TValue Unset { get; }
    public static abstract TValue Normal { get; }
    public static abstract TValue Flagged { get; }
    public static abstract TValue Deleted { get; }
}
