namespace Codespirals.Base
{
    /// <summary>
    /// The result from an <see cref="ISearch"/> query and all data necessary to implement pagination
    /// </summary>
    /// <typeparam name="TResult">The type of the search result items</typeparam>
    public interface ISearchResult<TSearch, TData> : ISearchResultWithoutData<TSearch>, IResult<List<TData>>
        where TSearch : ISearch
    {

    }
}