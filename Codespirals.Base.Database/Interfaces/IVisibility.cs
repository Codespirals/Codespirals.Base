namespace Codespirals.Base
{
    public partial interface IVisibility : IVisibility<int>
    {

    }
    public partial interface IVisibility<TValue>
        where TValue : IComparable
    {
        public static abstract TValue Public { get; }
        public static abstract TValue Unlisted { get; }
        public static abstract TValue Private { get; }
        public static abstract TValue Hidden { get; }
    }
}
