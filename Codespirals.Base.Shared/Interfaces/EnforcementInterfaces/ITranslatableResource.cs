namespace Codespirals.Base;

/// <summary>
/// A simple resource with the language id of the language it's in
/// </summary>
public interface ITranslatableResource : ISelectableBase
{
    // values differing by translation -> require setter
    /// <summary>
    /// The id of the language this resource object is in
    /// </summary>
    public string LanguageId { get; }
}

/// <summary>
/// A simple resource with the language id of the language it's in
/// </summary>
public interface ITranslatableResource<TId> : ISelectableBase<TId>
{
    // values differing by translation -> require setter
    /// <summary>
    /// The id of the language this resource object is in
    /// </summary>
    public string LanguageId { get; }
}
