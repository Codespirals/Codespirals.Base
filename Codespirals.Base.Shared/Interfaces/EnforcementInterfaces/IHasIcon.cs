namespace Codespirals.Base;

public interface IHasIcon
{
    /// <summary>
    /// An icon string that will be rendered as a small image on a website.
    /// For example, a unicode icon or a Font Awesome icon
    /// </summary>
    /// <example>❤</example>
    string? Icon { get; }
}
