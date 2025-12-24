namespace Codespirals.Base.Results;

/// <inheritdoc />
public record Result : IResult<Result, string>
{
    /// <inheritdoc />
    public bool Success { get; private set; }
    /// <inheritdoc />
    public string Error { get; private set; } = "";
    /// <inheritdoc />
    public string? ErrorCode { get; private set; }
    private Result()
    {
        Success = true;
    }
    private Result(string error, string? errorCode)
    {
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }

    /// <inheritdoc />
    public static Result Ok() => new();
    /// <inheritdoc />
    public static Result Fail(string error, string? errorCode = null) => new(error, errorCode);
    /// <inheritdoc />
    public static Result Short(IResult<string> result) => Fail(result.Error, result.ErrorCode);
}

/// <inheritdoc />
public record Result<TData> : IResultWithData<Result<TData>, string, TData>
{
    /// <inheritdoc />
    public bool Success { get; private set; }
    /// <inheritdoc />
    public string Error { get; private set; } = "";
    /// <inheritdoc />
    public string? ErrorCode { get; private set; }
    /// <inheritdoc />
    public TData? Data { get; private set; }
    private Result()
    {
        Success = true;
    }
    private Result(string error, string? errorCode)
    {
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    private Result(TData? data)
    {
        Success = true;
        Data = data;
    }

    /// <inheritdoc />
    public static Result<TData> Ok(TData data) => new(data);
    /// <inheritdoc />
    public static Result<TData> Fail(string error, string? errorCode = null) => new(error, errorCode);
    /// <inheritdoc />
    public static Result<TData> Short(IResult<string> result) => Fail(result.Error, result.ErrorCode);
}
