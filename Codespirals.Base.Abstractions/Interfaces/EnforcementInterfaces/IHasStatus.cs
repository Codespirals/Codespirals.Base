namespace Codespirals.Base
{
    public interface IHasStatus<TStatus>
        where TStatus : IComparable
    {
        public TStatus Status { get; }
    }
    public interface IHasStatus : IHasStatus<string>
    {

    }
}
