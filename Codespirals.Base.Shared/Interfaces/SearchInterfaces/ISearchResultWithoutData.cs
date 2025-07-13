
namespace Codespirals.Base
{
    /// <summary>
    /// An intermediate interface for search results that do not contain data.
    /// Very useful for pagination controls or similar that only need to know the parameters and total results.
    /// </summary>
    /// <typeparam name="TSearch"></typeparam>
    public interface ISearchResultWithoutData<TSearch>
        where TSearch : ISearch
    {
        /// <summary>
        /// The parameters used to create this search
        /// </summary>
        TSearch Parameters { get; }
        /// <summary>
        /// The total number of search results that matched the parameters
        /// </summary>
        int TotalResults { get; }
    }
}
