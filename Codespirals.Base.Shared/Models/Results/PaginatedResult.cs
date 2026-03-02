using Codespirals.Base.Filtering;

namespace Codespirals.Base.Results;

/// <summary>
/// This model represents the results value of a method that returns a list of items.
/// These items are filtered by the given <see cref="IFilterParameters"/> and can be paginated.
/// </summary>
/// <typeparam name="TData">The item type that was searched for</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters</typeparam>
public record PaginatedResult<TData, TFilterParameters> : IPaginatedResult<PaginatedResult<TData, TFilterParameters>, string, TData, TFilterParameters>
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

    private PaginatedResult(string error, string? errorCode = null)
    {
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private PaginatedResult(TFilterParameters filter, string error, string? errorCode = null) : this(error, errorCode)
    {
        Parameters = filter;
        Success = false;
    }
    private PaginatedResult(IEnumerable<TData> formattedData, TFilterParameters filter, int totalResults)
    {
        Parameters = filter;
        Success = true;
        TotalResults = totalResults;
        Data = formattedData;
    }
    private PaginatedResult(IEnumerable<TData> data, TFilterParameters filter, bool isSorted = true)
    {
        Parameters = filter;
        Success = true;
        Data = data.ApplyPagination(filter, out var totalResults, short.MaxValue, isSorted);
        TotalResults = totalResults;
    }
    /// <inheritdoc />
    public static PaginatedResult<TData, TFilterParameters> Ok(IEnumerable<TData> formattedData, TFilterParameters filter, int totalResults) => new(formattedData, filter, totalResults);
    /// <inheritdoc />
    public static PaginatedResult<TData, TFilterParameters> OkAndApplyPagination(IEnumerable<TData> data, TFilterParameters filter, bool isSorted = true) => new(data, filter, isSorted);
    /// <inheritdoc />
    public static PaginatedResult<TData, TFilterParameters> Fail(TFilterParameters filter, string error, string? errorCode = null) => new(filter, error, errorCode);
    /// <inheritdoc />
    public static PaginatedResult<TData, TFilterParameters> Short(IResult<string> result) => new(result.Error, result.ErrorCode);
}
