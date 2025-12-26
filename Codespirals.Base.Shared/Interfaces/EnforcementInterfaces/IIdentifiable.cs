namespace Codespirals.Base;

/// <summary>
/// Anything implementing this interface is guaranteed to have a unique identifier.
/// </summary>
/// <remarks>Honestly this only exists so I don't have to write the documentation for every class</remarks>
public interface IIdentifiable : IIdentifiable<string>
{

}
/// <inheritdoc cref="IIdentifiable"/>
/// <typeparam name="TId">The type of the Id property</typeparam>
public interface IIdentifiable<TId>
{
    /// <summary>
    /// A globally unique identifier (in most cases is a string representation of a <see cref="Guid"/>)
    /// </summary>
    TId Id { get; }
}
