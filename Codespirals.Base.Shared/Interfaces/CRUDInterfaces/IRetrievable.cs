namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are the base operations present that allow retrieving a resource.
    /// </summary>
    /// <typeparam name="TResult">The type of object representing the result of the operation</typeparam>
    /// <typeparam name="TId">The type with which to identify an object. Usually <see cref="int"/> or <see cref="string"/></typeparam>
    public interface IRetrievable<TResult, TId>
    {
        /// <summary>
        /// Get an item of the defined type with the given ID
        /// </summary>
        /// <param name="id">id of the item to retrieve</param>
        /// <returns>An item of the specified type</returns>
        public TResult Get(TId id);
    }
    /// <inheritdoc cref="IRetrievable{TResult, TId}"/>
    /// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
    public interface IRetrievable<TResult, TId, TVerification>
    {
        /// <inheritdoc cref="IRetrievable{TResult, TId}.Get(TId)"/>
        /// <param name="verification">An item to verify the user of this method with.</param>
        public TResult Get(TId id, TVerification verification);
    }
    /// <inheritdoc cref="IRetrievable{TResult, TId}"/>
    public interface IRetrievableAsync<TResult, TId>
    {
        /// <inheritdoc cref="IRetrievable{TResult, TId}.Get(TId)"/>
        public Task<TResult> GetAsync(TId id);
    }
    /// <inheritdoc cref="IRetrievable{TResult, TId, TVerification}"/>
    public interface IRetrievableAsync<TResult, TId, TVerification>
    {
        /// <inheritdoc cref="IRetrievable{TResult, TId, TVerification}.Get(TId, TVerification)"/>
        public Task<TResult> GetAsync(TId id, TVerification verification);
    }
}
