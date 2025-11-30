namespace Codespirals.Base;

/// <summary>
/// The result from a searh query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TSelf">The class implementing this</typeparam>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
/// <typeparam name="TData">The type of the search result items</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters.</typeparam>
public interface IFilteredListResult<TSelf, TErrorCode, TData, TFilterParameters> : IPagination<TFilterParameters>, IResult<TSelf, TErrorCode>
    where TSelf : IFilteredListResult<TSelf, TErrorCode, TData, TFilterParameters>
    where TFilterParameters : IFilterParameters
{
    /// <summary>
    /// The data returned by the operation.
    /// </summary>
    public IEnumerable<TData>? Data { get; }

    /// <summary>
    /// Returns a success result with the requested data, filtered by the <see cref="TFilterParameters"/>
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="data"></param>
    /// <param name="totalResults"></param>
    /// <returns></returns>
    public abstract static TSelf Ok(TFilterParameters filter, IEnumerable<TData> data, int totalResults);
}