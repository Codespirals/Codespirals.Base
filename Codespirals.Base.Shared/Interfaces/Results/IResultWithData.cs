namespace Codespirals.Base;

/// <summary>
/// A full result with data
/// </summary>
/// <typeparam name="TData">The type of the data</typeparam>
public interface IResultWithData<TSelf, TErrorCode, TData> : IResult<TSelf, TErrorCode>
    where TSelf : IResultWithData<TSelf, TErrorCode, TData>
{
    /// <summary>
    /// The data returned by the operation.
    /// </summary>
    public TData? Data { get; }
}
