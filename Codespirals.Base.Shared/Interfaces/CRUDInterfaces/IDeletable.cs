namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are the base operations present that allow deleting a resource.
    /// </summary>
    /// <typeparam name="TResult">The read or get class</typeparam>
    public interface IDeletable<TResult, TId>
    {
        /// <summary>
        /// Delete an item of the defined type with the given ID
        /// </summary>
        /// <param name="id">The id of the object to delete</param>
        /// <returns>
        /// An item of the specified type. 
        /// Usually this is used to indicate if the deletion was successful.
        /// </returns>
        public TResult Delete(TId id);
    }
    /// <inheritdoc/>
    public interface IDeletableAsync<TResult, TId> : IDeletable<Task<TResult>, TId>
    {

    }
}
