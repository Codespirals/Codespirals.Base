namespace Codespirals.Base;

/// <summary>
/// The base interface implemented by all result pattern classes and interfaces.
/// </summary>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking. Type to be decided on implementation.</typeparam>
public interface IResult<TErrorCode>
{
    /// <summary>
    /// Whether the operation that produced this result has succeeded
    /// </summary>
    public bool Success { get; }
    /// <summary>
    /// The optional error code for easier tracking of errors.
    /// </summary>
    public TErrorCode? ErrorCode { get; }
    /// <summary>
    /// The error message
    /// </summary>
    public string Error { get; }
}

/// <summary>
/// An item implementing this uses the Result Pattern
/// </summary>
/// <typeparam name="TSelf">The class implementing this</typeparam>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
public interface IResult<TSelf, TErrorCode> : IResult<TErrorCode>
    where TSelf : IResult<TSelf, TErrorCode>
{
    /// <summary>
    /// Return a result with a fail state
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <param name="errorCode">The optional error code.</param>
    /// <returns></returns>
    abstract static TSelf Fail(string error, TErrorCode? errorCode = default);
    /// <summary>
    /// Short Circuit a fail result from any result type implementing <see cref="IResult{TErrorCode}"/>
    /// </summary>
    /// <remarks>Only works with fail. A success can't be passed through as it may contain various kinds of incompatible data.</remarks>
    /// <param name="result"></param>
    /// <returns></returns>
    public abstract static TSelf Short(IResult<TErrorCode> result);
}
