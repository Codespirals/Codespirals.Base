namespace Codespirals.Base;

/// <summary>
/// Anything that implements this interface can be edited by the <see cref="Models.User.User"/>s that have permission to
/// </summary>
public interface IEditable
{
    /// <summary>
    /// The last time this was edited, or <see langword="null"/> if never
    /// </summary>
    public DateTime? Edited { get; }
}
