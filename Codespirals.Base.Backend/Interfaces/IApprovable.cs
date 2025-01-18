namespace Codespirals.Base
{
    public interface IApprovable<TApproval, TValue>
        where TApproval : IApproval<TValue>
        where TValue : ISelectableBase
    {
        public TValue Approval { get; }
    }
}
