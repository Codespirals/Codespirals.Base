namespace Codespirals.Base.Results;
/// <summary>
/// Indicates that an item implementing this has some form of data
/// </summary>
/// <typeparam name="TData"></typeparam>
public interface IHasData<TData>
{
    /// <summary>
    /// The data returned by the operation.
    /// </summary>
    TData? Data { get; }
}
