namespace Codespirals.Generic.Interfaces
{
    /// <summary>
    /// Anything implementing this interface is guaranteed to have a unique identifier.
    /// </summary>
    /// <remarks>Honestly this only exists so I don't have to write the documentation for every class</remarks>
    public interface IIdentifiable
    {
        /// <summary>
        /// A globally unique identifier (unless explicitly stated otherwise this is a <see cref="Guid"/>)
        /// </summary>
        /// <example>00000000-0000-0000-0000-000000000000</example>
        public string Id { get; }
    }
}
