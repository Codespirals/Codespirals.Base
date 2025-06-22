
namespace Codespirals.Base
{
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
