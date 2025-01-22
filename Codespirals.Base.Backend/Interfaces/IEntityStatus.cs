namespace Codespirals.Base
{
    public partial interface IEntityStatus<TValue> : IIsEnum<TValue>
        where TValue : ISelectableBase
    {
        public static abstract TValue Unset { get; }
        public static abstract TValue Normal { get; }
        public static abstract TValue Flagged { get; }
        public static abstract TValue Deleted { get; }
    }
}
