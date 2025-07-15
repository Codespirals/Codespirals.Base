namespace Codespirals.Base
{
    public record Result<TData> : IResult<TData>
    {
        public bool Success { get; internal set; }
        public string Error { get; internal set; } = "";
        public int ErrorCode { get; internal set; }
        public TData? Data { get; internal set; }
        internal Result()
        {
            Success = true;
        }
        internal Result(string error, int errorCode)
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

        public static Result<TData> Ok() => new();
        public static Result<TData> Ok(TData data) => new(data);
        public static Result<TData> Fail(string error, int errorCode = 0) => new(error, errorCode);
        public static Result<TData> Fail(Result result) => new(result.Error, result.ErrorCode);
    }
    public record Result : Result<object>
    {
        private Result() : base()
        {
            Data = null;
        }
        private Result(string error, int errorCode) : base(error, errorCode)
        {

        }
        public new static Result Fail(string error, int errorCode = 0) => new(error, errorCode);
        public new static Result Ok() => new();
    }
}
