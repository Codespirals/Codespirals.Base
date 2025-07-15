namespace Codespirals.Base
{
    /// <summary>
    /// The result from a searh query and all data necessary to implement pagination
    /// </summary>
    /// <typeparam name="TResult">The type of the search result items</typeparam>
    public interface ISearchResult<TSearchParameters, TData> : IPagination<TSearchParameters>, IResult<List<TData>>
        where TSearchParameters : ISearchParameters
    {

    }
}