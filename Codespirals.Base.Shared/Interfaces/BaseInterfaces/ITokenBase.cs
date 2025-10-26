namespace Codespirals.Base;

/// <summary>
/// A simple token usually for HTTP use
/// </summary>
/// <remarks>While it would make sense to use a <see cref="KeyValuePair"/>, storing those in a database can cause issues I wish to avoid.</remarks>
public interface ITokenBase : ICreatable
{
    /// <summary>
    /// The key or name of the token
    /// </summary>
    public string Key { get; }
    /// <summary>
    /// The value of the token. Should be unique and as close to impossible to guess as possible.
    /// </summary>
    /// <remarks>
    /// Usually something like a <see cref="Guid"/>
    /// </remarks>
    public string Value { get; }
    /// <summary>
    /// How long the token stays valid in minutes
    /// </summary>
    /// <remarks><see langword="null"/> if the token shouldn't be autmatically invalidated.</remarks>
    public int? MinutesToLive { get; }
    /// <summary>
    /// If the token is valid
    /// </summary>
    public bool IsValid { get; }
}
