
namespace Codespirals.Base
{
    /// <summary>
    /// An intermediate interface for search results that do not contain data.
    /// Very useful for pagination controls or similar that only need to know the parameters and total results.
    /// </summary>
    /// <typeparam name="TParamters"></typeparam>
    public interface IPagination<TParamters>
        where TParamters : IFilterParameters
    {
        /// <summary>
        /// The parameters used to create this search
        /// </summary>
        TParamters Parameters { get; }
        /// <summary>
        /// The total number of search results that matched the parameters
        /// </summary>
        int TotalResults { get; }
    }
}
