namespace Codespirals.Base.Results;
public interface IHasData<TData>
{
    /// <summary>
    /// The data returned by the operation.
    /// </summary>
    TData? Data { get; }
}
