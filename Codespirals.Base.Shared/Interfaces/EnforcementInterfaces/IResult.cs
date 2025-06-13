namespace Codespirals.Base
{
    public interface IResult<TSelf>
        where TSelf : IResult<TSelf>
    {
        public bool Success { get; }
        public int ErrorCode { get; }
        public string Error { get; }
        public TSelf OK();
        public TSelf Fail(int errocCode, string error);
    }
    public interface IResult<TSelf, TData> : IResult<TSelf>
        where TSelf : IResult<TSelf, TData>
    {
        public TData? Data { get; }
        public TSelf OK(TData data);
    }
}
