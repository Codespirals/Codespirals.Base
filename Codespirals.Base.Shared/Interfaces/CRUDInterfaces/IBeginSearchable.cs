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
    public interface IBeginSearchable<TSearch, TVerificaion>
        where TSearch : ISearchParameters
    {
        /// <summary>
        /// Request a search object to start searching with
        /// </summary>
        /// <returns>The search object</returns>
        public TSearch BeginSearch(TVerificaion verificaion);
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
    /// <inheritdoc />
    public interface IBeginSearchableAsync<TSearch, TVerification>
        where TSearch : ISearchParameters
    {
        /// <summary>
        /// Request a search object to start searching with
        /// </summary>
        /// <returns>The search object</returns>
        /// <inheritdoc />
        public Task<TSearch> BeginSearchAsync(TVerification verification);
    }
}
