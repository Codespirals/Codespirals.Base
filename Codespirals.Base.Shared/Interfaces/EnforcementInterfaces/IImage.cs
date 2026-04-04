namespace Codespirals.Base;

/// <summary>
/// 
/// </summary>
public interface IImage : IHasUrl
{
    /// <summary>
    /// A short description of what is in the image. Mainly to help people with impaired vision
    /// </summary>
    string AltText { get; }
    /// <summary>
    /// Credit to the entity that made the image
    /// </summary>
    string Credit { get; }
}
