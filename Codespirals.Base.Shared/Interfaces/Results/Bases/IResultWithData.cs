namespace Codespirals.Base
{
    /// <summary>
    /// A full result with data
    /// </summary>
    /// <typeparam name="TData">The type of the data</typeparam>
    public interface IResultWithData<TSelf, TErrorCode, TData> : IResult<TSelf, TErrorCode>
        where TSelf : IResultWithData<TSelf, TErrorCode, TData>
    {
        public TData? Data { get; }
    }
}
