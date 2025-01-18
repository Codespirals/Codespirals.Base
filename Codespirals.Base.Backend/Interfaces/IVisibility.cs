namespace Codespirals.Base
{
    public partial interface IVisibility<TValue>
        where TValue : ISelectableBase
    {
        public static abstract TValue Public { get; }
        public static abstract TValue Unlisted { get; }
        public static abstract TValue Private { get; }
        public static abstract TValue Hidden { get; }
    }
}
