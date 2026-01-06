namespace Codespirals.Base;

/// <summary>
/// Anything that implements this interface can be edited
/// </summary>
public interface IEditable
{
    /// <summary>
    /// The last time this was edited, or <see langword="null"/> if never
    /// </summary>
    DateTime? Edited { get; }
}
