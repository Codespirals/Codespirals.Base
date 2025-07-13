namespace Codespirals.Base
{
    /// <summary>
    /// A service implementing this interface implements a search function
    /// </summary>
    /// <typeparam name="TSearch">The search paramters implementing <see cref="ISearch"/></typeparam>
    /// <typeparam name="TSearchResult">The result implementing <see cref="ISearchResult{TSearch, TResult}"/></typeparam>
    /// <typeparam name="TData">The type to return in the search results</typeparam>
    public interface ISearchable<TSearchResult, TData, TSearch>
        where TSearch : ISearch
        where TSearchResult : ISearchResult<TSearch, TData>
    {
        public TSearchResult Search(TSearch search);
    }
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <typeparam name="TSearchResult"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TSearch"></typeparam>
    public interface ISearchableAsync<TSearchResult, TData, TSearch> : ISearchable<TSearchResult, TData, TSearch>
        where TSearch : ISearch
        where TSearchResult : ISearchResult<TSearch, TData>
    {
        public new Task<TSearchResult> Search(TSearch search);
    }
}
