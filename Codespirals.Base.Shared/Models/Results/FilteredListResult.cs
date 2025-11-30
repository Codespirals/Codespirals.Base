namespace Codespirals.Base;

/// <summary>
/// This model represents the results value of a method that returns a list of items.
/// These items are filtered by a filter query and can be paginated.
/// </summary>
/// <typeparam name="TData">The item type that was searched for</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters</typeparam>
public record FilteredListResult<TFilterParameters, TData> : IFilteredListResult<FilteredListResult<TFilterParameters, TData>, string, TData, TFilterParameters>
    where TFilterParameters : IFilterParameters, new()
{
    /// <inheritdoc/>
    public TFilterParameters Parameters { get; private set; } = new();
    /// <inheritdoc/>
    public int TotalResults { get; private set; }
    public bool Success { get; private set; }
    public string Error { get; private set; } = "";
    public string? ErrorCode { get; private set; }
    public IEnumerable<TData> Data { get; private set; } = [];

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
    private FilteredListResult(TFilterParameters filter, IEnumerable<TData> unformattedData)
    {
        Parameters = filter;
        Success = true;
        Data = unformattedData.ApplyFilterParameters(filter, short.MaxValue, out var totalResults);
        TotalResults = totalResults;
    }
    public static FilteredListResult<TFilterParameters, TData> Ok(TFilterParameters filter, IEnumerable<TData> formattedData, int totalResults) => new(filter, formattedData, totalResults);
    public static FilteredListResult<TFilterParameters, TData> OkAndFormat(TFilterParameters filter, IEnumerable<TData> unformattedData) => new(filter, unformattedData);
    public static FilteredListResult<TFilterParameters, TData> Fail(string error, string? errorCode = null) => new(error, errorCode);
    public static FilteredListResult<TFilterParameters, TData> Fail(TFilterParameters filter, string error, string? errorCode = null) => new(filter, error, errorCode);
    public static FilteredListResult<TFilterParameters, TData> Short(IResult<string> result) => new(result.Error, result.ErrorCode);
}
