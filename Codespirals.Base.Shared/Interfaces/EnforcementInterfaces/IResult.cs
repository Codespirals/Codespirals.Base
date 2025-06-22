namespace Codespirals.Base
{
    /// <summary>
    /// A result without data - basically a boolean with a potential error message
    /// </summary>
    public interface IResult
    {
        public bool Success { get; }
        public int ErrorCode { get; }
        public string Error { get; }
    }
    /// <summary>
    /// A full result with data
    /// </summary>
    /// <typeparam name="TData">The type of the data</typeparam>
    public interface IResult<TData> : IResult
    {
        public TData? Data { get; }
    }
}
