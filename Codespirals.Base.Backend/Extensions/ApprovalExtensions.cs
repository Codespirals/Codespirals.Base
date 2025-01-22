namespace Codespirals.Base
{
    public static class ApprovalExtensions
    {
        public static bool IsApproved<TApprovalOptions, TApprovalValue>(this IApprovable<TApprovalValue> approvable)
            where TApprovalOptions : IApprovals<TApprovalValue>
            where TApprovalValue : ISelectableBase
            => approvable.Approval.Is(TApprovalOptions.Approved);
    }
}
