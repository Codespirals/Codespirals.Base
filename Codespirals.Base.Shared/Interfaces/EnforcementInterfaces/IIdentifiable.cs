namespace Codespirals.Base
{
    /// <summary>
    /// Anything implementing this interface is guaranteed to have a unique identifier.
    /// </summary>
    /// <remarks>Honestly this only exists so I don't have to write the documentation for every class</remarks>
    public interface IIdentifiable
    {
        /// <summary>
        /// A globally unique identifier (in most cases is a string representation of a <see cref="Guid"/>)
        /// </summary>
        public string Id { get; }
    }
}
