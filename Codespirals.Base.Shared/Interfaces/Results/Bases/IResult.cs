namespace Codespirals.Base
{
    public interface IResult<TSelf, TErrorCode>
        where TSelf : IResult<TSelf, TErrorCode>
    {
        public bool Success { get; }
        public TErrorCode? ErrorCode { get; }
        public string Error { get; }
        public abstract static TSelf Fail(string error, TErrorCode? errorCode = default);
    }
}
