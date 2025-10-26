namespace Codespirals.Base;

/// <summary>
/// This model represents the results value of a method that returns a list of items.
/// These items are filtered by a filter query and can be paginated.
/// </summary>
/// <typeparam name="TData">The item type that was searched for</typeparam>
/// <typeparam name="TFilterParameters">The filter parameters</typeparam>
public record ListResult<TData> : IListResult<ListResult<TData>, string, TData>
{
    public bool Success { get; internal set; }
    public string Error { get; internal set; } = "";
    public string? ErrorCode { get; internal set; }
    public IEnumerable<TData> Data { get; internal set; } = [];

    private ListResult(string error, string? errorCode = null)
    {
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private ListResult(IEnumerable<TData> data)
    {
        Success = true;
        Data = data;
    }
    public static ListResult<TData> Ok(IEnumerable<TData> formattedData) => new(formattedData);
    public static ListResult<TData> Fail(string error, string? errorCode = null) => new(error, errorCode);
}
