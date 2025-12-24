namespace Codespirals.Base;

public interface ISortingTypes<TSelf> : IIsEnum<TSelf>
    where TSelf : ISortingTypes<TSelf>
{
    public static abstract TSelf Unsorted { get; }
}
