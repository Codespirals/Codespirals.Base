namespace Codespirals.Base
{
    public interface IApprovable<TValue>
    {
        public TValue Approval { get; }
    }
}
