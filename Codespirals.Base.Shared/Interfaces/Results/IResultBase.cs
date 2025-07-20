namespace Codespirals.Base
{
    /// <summary>
    /// A result without data - basically a boolean with a potential error message
    /// </summary>
    public interface IResultBase<TSelf>
        where TSelf : IResultBase<TSelf>
    {
        public bool Success { get; }
        public int ErrorCode { get; }
        public string Error { get; }
    }
    /// <summary>
    /// A result without data - basically a boolean with a potential error message
    /// </summary>
    public interface IResultBase<TSelf, TData> : IResultBase<TSelf>
        where TSelf : IResultBase<TSelf, TData>
    {
        public TData? Data { get; }
    }
}
