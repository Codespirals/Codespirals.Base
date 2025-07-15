namespace Codespirals.Base
{
    /// <summary>
    /// A service implementing this interface implements a search function
    /// </summary>
    /// <typeparam name="TFilter">The search paramters implementing <see cref="ISearchParameters"/></typeparam>
    /// <typeparam name="TListResult">The result implementing <see cref="IListResult{TSearchParameters, TData}"/></typeparam>
    /// <typeparam name="TData">The type to return in the search results</typeparam>
    public interface IListable<TFilter, TData, TListResult>
        where TFilter : IFilterParameters
        where TListResult : IListResult<TFilter, TData>
    {
        public TListResult GetMany(TFilter search);
    }
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <typeparam name="TListResult"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TFilter"></typeparam>
    public interface IListableAsync<TFilter, TData, TListResult>
        where TFilter : IFilterParameters
        where TListResult : IListResult<TFilter, TData>
    {
        public Task<TListResult> GetManyAsync(TFilter search);
    }
}
