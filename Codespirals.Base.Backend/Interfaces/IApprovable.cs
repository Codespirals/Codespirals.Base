namespace Codespirals.Base
{
    public interface IApprovable<TValue>
        where TValue : ISelectableBase
    {
        public TValue Approval { get; }
    }
}
