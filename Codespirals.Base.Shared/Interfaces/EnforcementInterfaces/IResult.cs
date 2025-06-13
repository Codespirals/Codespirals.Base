namespace Codespirals.Base
{
    public interface IResult
    {
        public bool Success { get; }
        public int ErrorCode { get; set; }
        public string Error { get; }
    }
    public interface IResult<TData> : IResult
    {
        public TData? Data { get; }
    }
}
