using Codespirals.Base.Filtering;

namespace Codespirals.Base.Results;

/// <summary>
/// The result from a searh query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
/// <typeparam name="TData">The type of the search result items</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters.</typeparam>
public interface IPaginatedResult<TErrorCode, TData, TFilterParameters> : IResultWithData<TErrorCode, IEnumerable<TData>>, IPagination<TFilterParameters>
    where TFilterParameters : IFilterParameters
{

}

/// <summary>
/// The result from a searh query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
/// <typeparam name="TData">The type of the search result items</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters.</typeparam>
/// <typeparam name="TSelf">The class implementing this</typeparam>
public interface IPaginatedResult<TSelf, TErrorCode, TData, TFilterParameters> : IPaginatedResult<TErrorCode, TData, TFilterParameters>
    where TSelf : IPaginatedResult<TSelf, TErrorCode, TData, TFilterParameters>
    where TFilterParameters : IFilterParameters
{
    /// <summary>
    /// Creates a successful result containing the specified filter parameters, formatted data, and total result count.
    /// </summary>
    /// <param name="filter">The filter parameters used to generate the result.</param>
    /// <param name="formattedData">The collection of formatted data items included in the result.</param>
    /// <param name="totalResults">The total number of results matching the filter criteria.</param>
    /// <returns>An instance of <typeparamref name="TSelf"/> representing a successful result.</returns>
    static abstract TSelf Ok(IEnumerable<TData> formattedData, TFilterParameters filter, int totalResults);
    /// <summary>
    /// Creates a successful result from ALL results and paginates those.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="filter"></param>
    /// <param name="isSorted"></param>
    /// <param name="maxLimit">Set an upper bound for how many items can be returned</param>
    /// <remarks>This method will attempt to sort by a property name given in <see cref="IFilterParameters.Sort"/>. If this is not desired, set <paramref name="isSorted"/> to true.</remarks>
    /// <returns></returns>
    static abstract TSelf OkAndApplyPagination(IEnumerable<TData> data, TFilterParameters filter, bool isSorted = true, int maxLimit = -1);
    /// <summary>
    /// Create a failed result
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="error"></param>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    static abstract TSelf Fail(TFilterParameters filter, string error, string? errorCode = null);
    /// <summary>
    /// Short a failed result but retain the filter parameters
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    static abstract TSelf Short(IResult<TErrorCode> result, TFilterParameters filter);
}