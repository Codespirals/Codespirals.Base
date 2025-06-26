namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are the base operations present that allow retrieving a resource.
    /// </summary>
    /// <typeparam name="TResult">The read or get class</typeparam>
    public interface IRetrievable<TResult, TId>
    {
        /// <summary>
        /// Get an item of the defined type with the given ID
        /// </summary>
        /// <param name="id">id of the item to retrieve</param>
        /// <returns>An item of the specified type</returns>
        public TResult Get(TId id);
    }
    /// <inheritdoc/>
    public interface IRetrievableAsync<TResult, TId> : IRetrievable<Task<TResult>, TId>
    {

    }
}
