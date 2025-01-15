namespace Codespirals.Base
{
    public interface IEntityStatus : IEntityStatus<int>
    {

    }
    public interface IEntityStatus<TValue>
        where TValue : IComparable
    {
        public static abstract TValue Unset { get; }
        public static abstract TValue Normal { get; }
        public static abstract TValue Flagged { get; }
        public static abstract TValue Deleted { get; }
    }
}
