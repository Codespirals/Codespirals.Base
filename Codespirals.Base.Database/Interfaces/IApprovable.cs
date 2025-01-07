namespace Codespirals.Base
{
    public interface IApprovable<TApproval> : IApprovable<TApproval, int>
        where TApproval : IApproval
    {

    }
    public interface IApprovable<TApproval, TValue>
        where TApproval : IApproval<TValue>
        where TValue : IComparable
    {
        public TValue Approval { get; }
    }
}
