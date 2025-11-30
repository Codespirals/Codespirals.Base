namespace Codespirals.Base;

/// <summary>
/// The result from a search query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TSelf">The class implementing this</typeparam>
/// <typeparam name="TData">The type of the search result items</typeparam>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
/// <typeparam name="TSearchParameters">The filter parameters.</typeparam>
public interface ISearchResult<TSelf, TErrorCode, TData, TSearchParameters> : IFilteredListResult<TSelf, TErrorCode, TData, TSearchParameters>
    where TSelf : ISearchResult<TSelf, TErrorCode, TData, TSearchParameters>
    where TSearchParameters : ISearchParameters
{

}