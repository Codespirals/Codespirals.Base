namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are the base operations present that allow editing a resource.
    /// </summary>
    /// <typeparam name="TResult">The type of object representing the result of the operation</typeparam>
    /// <typeparam name="TEdit">The type of the object containing all data needed to update</typeparam>
    public interface IUpdatable<TResult, TEdit>
    {
        /// <summary>
        /// Update an item of the defined type with the given ID
        /// </summary>
        /// <param name="editItem">An object of the edit class for this operation</param>
        /// <returns>The updated item.</returns>
        public TResult Edit(TEdit editItem);
    }
    /// <inheritdoc cref="IUpdatable{TResult, TEdit}" />
    /// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
    public interface IUpdatable<TResult, TEdit, TVerification>
    {
        /// <inheritdoc cref="IUpdatable{TResult, TEdit}.Edit(TEdit)" />
        /// <param name="verification">An item to verify the user of this method with.</param>
        public TResult Edit(TEdit editItem, TVerification verification);
    }
    /// <inheritdoc cref="IUpdatable{TResult, TEdit}" />
    public interface IUpdatableAsync<TResult, TEdit>
    {
        /// <inheritdoc cref="IUpdatable{TResult, TEdit}.Edit(TEdit)" />
        public Task<TResult> EditAsync(TEdit editItem);
    }
    /// <inheritdoc cref="IUpdatable{TResult, TEdit, TVerification}" />
    public interface IUpdatableAsync<TResult, TEdit, TVerification>
    {
        /// <inheritdoc cref="IUpdatable{TResult, TEdit, TVerification}.Edit(TEdit, TVerification)" />
        public Task<TResult> EditAsync(TEdit editItem, TVerification verification);
    }
}
