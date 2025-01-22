namespace Codespirals.Base
{
    public partial interface IApproval<TValue> : IIsEnum<TValue>
        where TValue : ISelectableBase
    {
        public static abstract TValue Unchecked { get; }
        public static abstract TValue Pending { get; }
        public static abstract TValue Approved { get; }
        public static abstract TValue Denied { get; }
        public static abstract TValue Retracted { get; }
    }
}
