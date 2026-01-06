using Codespirals.Base.Filtering;

namespace Codespirals.Base.Results;

/// <summary>
/// This model represents the results value of a method that returns a list of items.
/// These items are filtered by the given <see cref="IFilterParameters"/> and can be paginated.
/// </summary>
/// <typeparam name="TData">The item type that was searched for</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters</typeparam>
public record FilteredListResult<TData, TFilterParameters> : IFilteredListResult<FilteredListResult<TData, TFilterParameters>, string, TData, TFilterParameters>
    where TFilterParameters : IFilterParameters, new()
{
    /// <inheritdoc />
    public bool Success { get; private set; }
    /// <inheritdoc />
    public string Error { get; private set; } = "";
    /// <inheritdoc />
    public string? ErrorCode { get; private set; }
    /// <inheritdoc />
    public TFilterParameters Parameters { get; private set; } = new();
    /// <inheritdoc />
    public IEnumerable<TData> Data { get; private set; } = [];
    /// <inheritdoc />
    public int TotalResults { get; private set; }

    private FilteredListResult(string error, string? errorCode = null)
    {
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private FilteredListResult(TFilterParameters filter, string error, string? errorCode = null) : this(error, errorCode)
    {
        Parameters = filter;
        Success = false;
    }
    private FilteredListResult(TFilterParameters filter, IEnumerable<TData> formattedData, int totalResults)
    {
        Parameters = filter;
        Success = true;
        TotalResults = totalResults;
        Data = formattedData;
    }
    private FilteredListResult(TFilterParameters filter, IEnumerable<TData> data, bool isSorted = false)
    {
        Parameters = filter;
        Success = true;
        Data = data.ApplyPagination(filter, short.MaxValue, out var totalResults, isSorted);
        TotalResults = totalResults;
    }
    /// <inheritdoc />
    public static FilteredListResult<TData, TFilterParameters> Ok(IEnumerable<TData> formattedData, TFilterParameters filter, int totalResults) => new(filter, formattedData, totalResults);
    /// <inheritdoc />
    public static FilteredListResult<TData, TFilterParameters> OkAndApplyPagination(IEnumerable<TData> data, TFilterParameters filter, bool isSorted = false) => new(filter, data, isSorted);
    /// <inheritdoc />
    public static FilteredListResult<TData, TFilterParameters> Fail(TFilterParameters filter, string error, string? errorCode = null) => new(filter, error, errorCode);
    /// <inheritdoc />
    public static FilteredListResult<TData, TFilterParameters> Short(IResult<string> result) => new(result.Error, result.ErrorCode);
}
