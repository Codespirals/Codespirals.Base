namespace Codespirals.Base;

/// <summary>
/// The result from a searh query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TResult">The type of the search result items</typeparam>
public interface IFilteredListResult<TSelf, TErrorCode, TFilterParameters, TData> : IPagination<TFilterParameters>, IListResult<TSelf, TErrorCode, TData>
    where TSelf : IFilteredListResult<TSelf, TErrorCode, TFilterParameters, TData>
    where TFilterParameters : IFilterParameters
{

}