namespace Codespirals.Base;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TStatus"></typeparam>
public interface IHasStatus<TStatus>
{
    /// <summary>
    /// A status that is usually one of a selection
    /// </summary>
    /// <example>An enum</example>
    public TStatus Status { get; }
}
