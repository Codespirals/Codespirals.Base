namespace Codespirals.Base
{
    public interface IHasStatus<TStatus>
    {
        /// <summary>
        /// A status that is usually one of a selection
        /// </summary>
        /// <example>An enum</example>
        public TStatus Status { get; }
    }
}
