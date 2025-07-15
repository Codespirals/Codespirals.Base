namespace Codespirals.Base
{
    /// <summary>
    /// A service implementing this interface requires the api to have a method to retrieve an object containing all data needed to start a search
    /// </summary>
    /// <typeparam name="TSearch">The type of the search object</typeparam>
    public interface IBeginSearchable<TSearch>
        where TSearch : ISearchParameters
    {
        /// <summary>
        /// Request a search object to start searching with
        /// </summary>
        /// <returns>The search object</returns>
        public TSearch BeginSearch();
    }
    /// <inheritdoc />
    public interface IBeginSearchableAsync<TSearch>
        where TSearch : ISearchParameters
    {
        /// <summary>
        /// Request a search object to start searching with
        /// </summary>
        /// <returns>The search object</returns>
        /// <inheritdoc />
        public Task<TSearch> BeginSearchAsync();
    }
}
