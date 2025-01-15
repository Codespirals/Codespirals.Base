namespace Codespirals.Base
{
    public interface IApproval : IApproval<int>
    {

    }
    public interface IApproval<TValue>
        where TValue : IComparable
    {
        public static abstract TValue Unchecked { get; }
        public static abstract TValue Pending { get; }
        public static abstract TValue Approved { get; }
        public static abstract TValue Denied { get; }
        public static abstract TValue Retracted { get; }
    }
}
