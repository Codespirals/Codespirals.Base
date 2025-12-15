namespace Codespirals.Base.Results;

/// <summary>
/// A full result with data
/// </summary>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
/// <typeparam name="TData">The type of the data</typeparam>
public interface IResultWithData<TErrorCode, TData> : IResult<TErrorCode>, IHasData<TData>
{

}

/// <inheritdoc cref="IResultWithData{TErrorCode, TData}"/>
/// <typeparam name="TSelf">The class implementing this</typeparam>
public interface IResultWithData<TSelf, TErrorCode, TData> : IResultWithData<TErrorCode, TData>, IResult<TSelf, TErrorCode>
    where TSelf : IResultWithData<TSelf, TErrorCode, TData>
{
    /// <summary>
    /// Creates a successful result containing the specified data.
    /// </summary>
    /// <param name="data">The data to include in the result. This value represents the successful outcome of the operation.</param>
    /// <returns>A new instance of <typeparamref name="TSelf"/> representing a successful result.</returns>
    public abstract static TSelf Ok(TData data);
}
