namespace Codespirals.Base;

/// <summary>
/// The result from a search query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TResult">The type of the search result items</typeparam>
public interface ISearchResult<TSelf, TErrorCode, TSearchParameters, TData> : IFilteredListResult<TSelf, TErrorCode, TSearchParameters, TData>
    where TSelf : ISearchResult<TSelf, TErrorCode, TSearchParameters, TData>
    where TSearchParameters : ISearchParameters
{

}