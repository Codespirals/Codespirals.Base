namespace Codespirals.Base
{
    /// <summary>
    /// The result from an <see cref="ISearch"/> query and all data necessary to implement pagination
    /// </summary>
    /// <typeparam name="TResult">The type of the search result items</typeparam>
    public interface ISearchResult<TSearch, TResult>
        where TSearch : ISearch
    {
        TSearch Search {  get; } 
        /// <summary>
        /// The total number of search results that matched the parameters
        /// </summary>
        int TotalResults { get; }
        /// <summary>
        /// The returned search results as filtered by the <see cref="ISearch"/> conditions
        /// </summary>
        ICollection<TResult> Results { get; }
    }
}