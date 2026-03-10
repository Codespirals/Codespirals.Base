using Codespirals.Base.Filtering;

namespace Codespirals.Base.Results;

/// <summary>
/// This model represents the results value of a method that returns a list of items.
/// These items are filtered by a search query and can be paginated.
/// </summary>
/// <typeparam name="TData">The item type that was searched for</typeparam>
/// <typeparam name="TSearchParameters">The search parameters</typeparam>
public record SearchResult<TData, TSearchParameters> : IPaginatedResult<SearchResult<TData, TSearchParameters>, string, TData, TSearchParameters>
    where TSearchParameters : ISearchParameters, new()
{
    /// <inheritdoc />
    public bool Success { get; private set; }
    /// <inheritdoc />
    public string Error { get; private set; } = "";
    /// <inheritdoc />
    public string? ErrorCode { get; private set; }
    /// <inheritdoc />
    public IEnumerable<TData> Data { get; private set; } = [];
    /// <inheritdoc />
    public int TotalResults { get; private set; }
    /// <inheritdoc />
    public TSearchParameters Parameters { get; private set; } = new();

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
    private SearchResult(IEnumerable<TData> formattedData, TSearchParameters filter, int totalResults)
    {
        Parameters = filter;
        Success = true;
        TotalResults = totalResults;
        Data = formattedData;
    }
    private SearchResult(IEnumerable<TData> unformattedData, TSearchParameters filter, bool isSorted = true, int maxLimit = -1)
    {
        Parameters = filter;
        Success = true;
        Data = unformattedData.ApplyPagination(filter, out var totalResults, maxLimit, isSorted);
        TotalResults = totalResults;
    }
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> Ok(IEnumerable<TData> formattedData, TSearchParameters filter, int totalResults) => new(formattedData, filter, totalResults);
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> OkAndApplyPagination(IEnumerable<TData> data, TSearchParameters filter, bool isSorted = true, int maxLimit = -1) => new(data, filter, isSorted, maxLimit);
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> Fail(TSearchParameters filter, string error, string? errorCode = null) => new(filter, error, errorCode);
    /// <inheritdoc cref="IResult{TSelf, TErrorCode}.Short(IResult{TErrorCode})" />
    public static SearchResult<TData, TSearchParameters> Short(IResult<string> result) => new(result.Error, result.ErrorCode);
    /// <inheritdoc />
    public static SearchResult<TData, TSearchParameters> Short(IResult<string> result, TSearchParameters filter) => new(filter, result.Error, result.ErrorCode);
}
