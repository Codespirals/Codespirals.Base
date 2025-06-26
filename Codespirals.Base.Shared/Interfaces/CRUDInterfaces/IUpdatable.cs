namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are the base operations present that allow editing a resource.
    /// </summary>
    /// <typeparam name="TResult">The type of the object to update</typeparam>
    /// <typeparam name="TEdit">The type of the object containing all data needed to update</typeparam>
    public interface IUpdatable<TResult, TEdit>
    {
        /// <summary>
        /// Update an item of the defined type with the given ID
        /// </summary>
        /// <param name="editItem">An object of the edit class for this type</param>
        /// <returns>The updated item.</returns>
        public TResult Edit(TEdit editItem);
    }
    /// <inheritdoc />
    public interface IUpdatableAsync<TResult, TEdit> : IUpdatable<Task<TResult>, TEdit>
    {

    }
}
