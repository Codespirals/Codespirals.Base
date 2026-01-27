namespace Codespirals.Base;

/// <summary>
/// This item can have a publish date
/// </summary>
public interface IPublishable
{
    /// <summary>
    /// When this item was published, or <see langword="null"/> if never
    /// </summary>
    DateTime? Published { get; }
}
