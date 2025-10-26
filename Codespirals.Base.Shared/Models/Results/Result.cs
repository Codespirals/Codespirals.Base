namespace Codespirals.Base;

public record Result<TData> : IResultWithData<Result<TData>, string, TData>
{
    public bool Success { get; internal set; }
    public string Error { get; internal set; } = "";
    public string? ErrorCode { get; internal set; }
    public TData? Data { get; internal set; }
    internal Result()
    {
        Success = true;
    }
    internal Result(string error, string? errorCode)
    {
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }
    internal Result(TData? data)
    {
        Success = true;
        Data = data;
    }

    public static Result<TData> Ok(TData data) => new(data);
    public static Result<TData> Fail(string error, string? errorCode = null) => new(error, errorCode);
    public static Result<TData> Short(Result<TData> result) => new(result.Error, result.ErrorCode);
}
public record Result : IResult<Result, string>
{
    public bool Success { get; internal set; }
    public string Error { get; internal set; } = "";
    public string? ErrorCode { get; internal set; }
    internal Result()
    {
        Success = true;
    }
    internal Result(string error, string? errorCode)
    {
        Success = false;
        Error = error;
        ErrorCode = errorCode;
    }

    public static Result Ok() => new();
    public static Result Fail(string error, string? errorCode = null) => new(error, errorCode);
}
