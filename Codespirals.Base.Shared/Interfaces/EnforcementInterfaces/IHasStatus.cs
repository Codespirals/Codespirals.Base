namespace Codespirals.Base
{
    public interface IHasStatus<TStatus>
    {
        public TStatus Status { get; }
    }
}
