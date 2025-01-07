namespace Codespirals.Base
{
    /// <summary>
    /// The result from an <see cref="ISearch"/> query and all data necessary to implement pagination
    /// </summary>
    /// <typeparam name="TResult">The type of the search result items</typeparam>
    public interface ISearchResult<TSearch, TResult>
        where TSearch : ISearch
    {
        TSearch Search { get; set; }
        /// <summary>
        /// The total number of search results that matched the parameters
        /// </summary>
        int TotalResults { get; set; }
        /// <summary>
        /// The returned search results as filtered by the <see cref="ISearch"/> conditions
        /// </summary>
        List<TResult> Results { get; set; }
    }
}