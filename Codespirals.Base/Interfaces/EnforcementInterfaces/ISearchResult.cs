namespace Codespirals.Base
{
    /// <summary>
    /// The result from an <see cref="ISearch"/> query
    /// </summary>
    /// <typeparam name="T">The type of the result objects</typeparam>
    public interface ISearchResult<T> : IPagination
    {
        /// <summary>
        /// The returned search results (max set by <seealso cref="ISearch.Limit"/>)
        /// </summary>
        ICollection<T> Results { get; }
    }
}