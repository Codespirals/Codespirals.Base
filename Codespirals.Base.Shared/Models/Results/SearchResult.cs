namespace Codespirals.Base;

/// <summary>
/// This model represents the results value of a method that returns a list of items.
/// These items are filtered by a search query and can be paginated.
/// </summary>
/// <typeparam name="TData">The item type that was searched for</typeparam>
/// <typeparam name="TSearchParameters">The search parameters</typeparam>
public record SearchResult<TData, TSearchParameters> : IFilteredListResult<SearchResult<TData, TSearchParameters>, string, TData, TSearchParameters>
    where TSearchParameters : ISearchParameters, new()
{
    /// <inheritdoc />
    public TSearchParameters Parameters { get; private set; }
    /// <inheritdoc />
    public int TotalResults { get; private set; }
    /// <inheritdoc />
    public bool Success { get; private set; }
    /// <inheritdoc />
    public string Error { get; private set; } = "";
    /// <inheritdoc />
    public string? ErrorCode { get; private set; }
    /// <inheritdoc />
    public IEnumerable<TData> Data { get; private set; } = [];

    private SearchResult(string error, string? errorCode = null)
    {
        Parameters = new TSearchParameters();
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private SearchResult(TSearchParameters filter, string error, string? errorCode = null) : this(error, errorCode)
    {
        Parameters = filter;
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private SearchResult(TSearchParameters filter, IEnumerable<TData> formattedData, int totalResults)
    {
        Parameters = filter;
        Success = true;
        TotalResults = totalResults;
        Data = formattedData;
    }
    private SearchResult(TSearchParameters filter, IEnumerable<TData> unformattedData)
    {
        Parameters = filter;
        Success = true;
        Data = unformattedData.ApplyFilterParameters(filter, short.MaxValue, out var totalResults);
        TotalResults = totalResults;
    }
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> Ok(IEnumerable<TData> formattedData, TSearchParameters filter, int totalResults) => new(filter, formattedData, totalResults);
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> OkAndFormat(IEnumerable<TData> unformattedData, TSearchParameters filter) => new(filter, unformattedData);
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> Fail(string error, string? errorCode = null) => new(error, errorCode);
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> Fail(TSearchParameters filter, string error, string? errorCode = null) => new(filter, error, errorCode);
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> Short(IResult<string> result) => Fail(result.Error, result.ErrorCode);
}
