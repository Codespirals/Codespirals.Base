namespace Codespirals.Base
{
    public interface IApprovable<TApproval>
        where TApproval : IApproval
    {
        public string Approval { get; }
    }
}
