namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are the base operations present that allow creating a resource.
    /// </summary>
    /// <typeparam name="TCreate">The type containing all the information needed to create a new object</typeparam>
    public interface ICreatable<TResult, TCreate>
    {
        /// <summary>
        /// Create an item of the defined type
        /// </summary>
        /// <param name="createItem">An object of the creation class for this type</param>
        /// <returns>The newly created item</returns>
        public TResult Create(TCreate createItem);
    }
    /// <inheritdoc/>
    public interface ICreatableAsync<TResult, TCreate>
    {
        /// <summary>
        /// Create an item of the defined type
        /// </summary>
        /// <param name="createItem">An object of the creation class for this type</param>
        /// <returns>The newly created item</returns>
        public Task<TResult> CreateAsync(TCreate createItem);
    }
}
