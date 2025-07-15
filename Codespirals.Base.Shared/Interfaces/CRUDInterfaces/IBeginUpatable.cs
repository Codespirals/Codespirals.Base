namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are the base operations present that allow retrieving or generating an object for editing a resource.
    /// </summary>
    /// <typeparam name="TEdit">The edit object</typeparam>
    /// <typeparam name="TId">The id of the object to edit</typeparam>
    public interface IBeginUpatable<TEdit, TId>
    {
        /// <summary>
        /// Get an object of the edit model for an item to begin editing it
        /// </summary>
        /// <param name="id">The Id of the item</param>
        /// <returns>The object of the edit model type</returns>
        public TEdit BeginEdit(TId id);
    }
    /// <inheritdoc />
    public interface IBeginUpatableAsync<TEdit, TId>
    {
        /// <summary>
        /// Get an object of the edit model for an item to begin editing it
        /// </summary>
        /// <param name="id">The Id of the item</param>
        /// <returns>The object of the edit model type</returns>
        public Task<TEdit> BeginEditAsync(TId id);
    }
}
