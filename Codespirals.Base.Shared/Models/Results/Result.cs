namespace Codespirals.Base;

public record Result<TData> : IResultWithData<Result<TData>, string, TData>
{
    public bool Success { get; private set; }
    public string Error { get; private set; } = "";
    public string? ErrorCode { get; private set; }
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

    public static Result<TData> Ok(TData data) => new(data);
    public static Result<TData> Fail(string error, string? errorCode = null) => new(error, errorCode);
    public static Result<TData> Short(IResult<string> result) => new(result.Error, result.ErrorCode);
}
public record Result : IResult<Result, string>
{
    public bool Success { get; private set; }
    public string Error { get; private set; } = "";
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

    public static Result Ok() => new();
    public static Result Fail(string error, string? errorCode = null) => new(error, errorCode);
    public static Result Short(IResult<string> result) => new(result.Error, result.ErrorCode);
}
