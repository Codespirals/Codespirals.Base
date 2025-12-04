using Codespirals.Base.Filtering;

namespace Codespirals.Base.Results;

/// <summary>
/// The result from a searh query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TSelf">The class implementing this</typeparam>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
/// <typeparam name="TData">The type of the search result items</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters.</typeparam>
public interface IFilteredListResult<TSelf, TErrorCode, TData, TFilterParameters> : IResult<TSelf, TErrorCode>, IPagination<TFilterParameters>, IHasData<IEnumerable<TData>>
    where TSelf : IFilteredListResult<TSelf, TErrorCode, TData, TFilterParameters>
    where TFilterParameters : IFilterParameters
{
    /// <summary>
    /// Creates a successful result containing the specified filter parameters, formatted data, and total result count.
    /// </summary>
    /// <param name="filter">The filter parameters used to generate the result.</param>
    /// <param name="formattedData">The collection of formatted data items included in the result.</param>
    /// <param name="totalResults">The total number of results matching the filter criteria.</param>
    /// <returns>An instance of <typeparamref name="TSelf"/> representing a successful result.</returns>
    public abstract static TSelf Ok(IEnumerable<TData> formattedData, TFilterParameters filter, int totalResults);
    /// <inheritdoc cref="IResult{TSelf, TErrorCode}.Fail(string, TErrorCode?)"/>
    /// <param name="filter">The filter parameters used to generate the result.</param>
    public abstract static TSelf Fail(TFilterParameters filter, string error, string? errorCode = null);
}