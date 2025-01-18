namespace Codespirals.Base
{
    public interface IHasStatus<TStatus>
    {
        public TStatus Status { get; }
    }
    public interface IHasStatus : IHasStatus<string>
    {

    }
}
