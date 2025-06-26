using Codespirals.Search;

namespace Codespirals.Base
{
    /// <summary>
    /// A service implementing this interface implements a search function
    /// </summary>
    /// <typeparam name="TSearch">The search paramters implementing <see cref="ISearch"/></typeparam>
    /// <typeparam name="TApiSearchResult">The result implementing <see cref="ISearchResult{TSearch, TResult}"/></typeparam>
    /// <typeparam name="TData">The type to return in the search results</typeparam>
    public interface ISearchable<TApiSearchResult, TData, TSearch>
        where TSearch : ISearch
        where TApiSearchResult : ISearchResult<TData, TSearch>
    {
        public TApiSearchResult Search(TSearch search);
    }
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <typeparam name="TApiSearchResult"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TSearch"></typeparam>
    public interface ISearchableAsync<TApiSearchResult, TData, TSearch> : ISearchable<TApiSearchResult, TData, TSearch>
        where TSearch : ISearch
        where TApiSearchResult : ISearchResult<TData, TSearch>
    {
        public new Task<TApiSearchResult> Search(TSearch search);
    }
}
