namespace Codespirals.Base;

/// <summary>
/// This model represents the results value of a method that returns a list of items.
/// These items are filtered by a search query and can be paginated.
/// </summary>
/// <typeparam name="TData">The item type that was searched for</typeparam>
/// <typeparam name="TSearchParameters">The search parameters</typeparam>
public record SearchResult<TSearchParameters, TData> : ISearchResult<SearchResult<TSearchParameters, TData>, string, TData, TSearchParameters>
    where TSearchParameters : ISearchParameters, new()
{
    /// <inheritdoc/>
    public TSearchParameters Parameters { get; private set; }
    /// <inheritdoc/>
    public int TotalResults { get; private set; }
    public bool Success { get; private set; }
    public string Error { get; private set; } = "";
    public string? ErrorCode { get; private set; }
    public IEnumerable<TData> Data { get; private set; } = [];

    private SearchResult(string error, string? errorCode = null)
    {
        Parameters = new TSearchParameters();
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private SearchResult(TSearchParameters search, string error, string? errorCode = null) : this(error, errorCode)
    {
        Parameters = search;
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private SearchResult(TSearchParameters search, IEnumerable<TData> formattedData, int totalResults)
    {
        Parameters = search;
        Success = true;
        TotalResults = totalResults;
        Data = formattedData;
    }
    private SearchResult(TSearchParameters search, IEnumerable<TData> unformattedData)
    {
        Parameters = search;
        Success = true;
        Data = unformattedData.ApplyFilterParameters(search, short.MaxValue, out var totalResults);
        TotalResults = totalResults;
    }
    public static SearchResult<TSearchParameters, TData> Ok(TSearchParameters search, IEnumerable<TData> formattedData, int totalResults) => new(search, formattedData, totalResults);
    public static SearchResult<TSearchParameters, TData> OkAndFormat(TSearchParameters search, IEnumerable<TData> unformattedData) => new(search, unformattedData);
    public static SearchResult<TSearchParameters, TData> Fail(string error, string? errorCode = null) => new(error, errorCode);
    public static SearchResult<TSearchParameters, TData> Fail(TSearchParameters search, string error, string? errorCode = null) => new(search, error, errorCode);
    public static SearchResult<TSearchParameters, TData> Short(IResult<string> result) => new(result.Error, result.ErrorCode);
}
