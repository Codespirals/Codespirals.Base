namespace Codespirals.Base.Results;

/// <summary>
/// The result from a searh query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TSelf">The class implementing this</typeparam>
/// <typeparam name="TErrorCode">An optional error code for swift and easy error tracking.</typeparam>
/// <typeparam name="TData">The type of the search result items</typeparam>
public interface IListResult<TSelf, TErrorCode, TData> : IResult<TSelf, TErrorCode>, IHasData<IEnumerable<TData>>
    where TSelf : IListResult<TSelf, TErrorCode, TData>
{
    /// <summary>
    /// Returns a successful result with the requested data
    /// </summary>
    /// <param name="data">A list of <see cref="TData"/></param>
    /// <returns></returns>
    public abstract static TSelf Ok(IEnumerable<TData> data);
}