namespace Codespirals.Base;

/// <summary>
/// The result from a searh query and all data necessary to implement pagination
/// </summary>
/// <typeparam name="TResult">The type of the search result items</typeparam>
public interface IListResult<TSelf, TErrorCode, TData> : IResultWithData<TSelf, TErrorCode, IEnumerable<TData>>
    where TSelf : IListResult<TSelf, TErrorCode, TData>
{

}