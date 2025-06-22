namespace Codespirals.Base
{
    public interface ISortingTypes<TSelf> : IIsEnum<TSelf>, ISelectableBase
        where TSelf : ISortingTypes<TSelf>
    {
        public static abstract TSelf Unsorted { get; }
    }
}
