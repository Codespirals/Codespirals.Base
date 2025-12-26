namespace Codespirals.Base;

public interface ISortingTypes<TSelf> : IIsEnum<TSelf>
    where TSelf : ISortingTypes<TSelf>
{
    static abstract TSelf Unsorted { get; }
}
