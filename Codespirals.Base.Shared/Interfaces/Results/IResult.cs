namespace Codespirals.Base;

/// <summary>
/// An item implementing this uses the Result Pattern
/// </summary>
/// <typeparam name="TSelf"></typeparam>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
public interface IResult<TSelf, TErrorCode>
    where TSelf : IResult<TSelf, TErrorCode>
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
    /// <summary>
    /// Return a result in a fail state
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <param name="errorCode">The optional error code.</param>
    /// <returns></returns>
    public abstract static TSelf Fail(string error, TErrorCode? errorCode = default);
}
