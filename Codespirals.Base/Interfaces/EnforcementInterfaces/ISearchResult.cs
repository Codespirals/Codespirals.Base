namespace Codespirals.Base
{
    /// <summary>
    /// The result from an <see cref="ISearch"/> query and all data necessary to implement pagination
    /// </summary>
    /// <typeparam name="T">The type of the search result items</typeparam>
    public interface ISearchResult<T> : IPagination
    {
        /// <summary>
        /// The returned search results as filtered by the <see cref="ISearch"/> conditions
        /// </summary>
        ICollection<T> Results { get; }
    }
}