namespace Codespirals.Base.CRUD;

/// <summary>
/// Services implementing this interface make sure there are the base operations present that allow editing a resource.
/// </summary>
/// <typeparam name="TResult">The type of object representing the result of the operation</typeparam>
/// <typeparam name="TEdit">The type of the object containing all data needed to update</typeparam>
/// <typeparam name="TId">The type of the Id of the item to update</typeparam>
public interface IUpdatable<TResult, TEdit, TId>
{
    /// <summary>
    /// Update an item of the defined type with the given ID
    /// </summary>
    /// <param name="id">The Id of the item to edit</param>
    /// <param name="editItem">An object of the edit class for this operation</param>
    /// <returns>The updated item.</returns>
    public TResult Edit(TId id, TEdit editItem);
}
/// <inheritdoc cref="IUpdatable{TResult, TEdit, TId}" />
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface IUpdatable<TResult, TEdit, TId, TVerification>
{
    /// <inheritdoc cref="IUpdatable{TResult, TEdit, TId}.Edit(TId, TEdit)" />
    /// <param name="verification">An item to verify the user of this method with.</param>
    public TResult Edit(TId id, TEdit editItem, TVerification verification);
}
/// <inheritdoc cref="IUpdatable{TResult, TEdit, TId}" />
public interface IUpdatableAsync<TResult, TEdit, TId>
{
    /// <inheritdoc cref="IUpdatable{TResult, TEdit, TId}.Edit(TId, TEdit)" />
    public Task<TResult> EditAsync(TId id, TEdit editItem);
}
/// <inheritdoc cref="IUpdatable{TResult, TEdit, TVerification}" />
public interface IUpdatableAsync<TResult, TEdit, TId, TVerification>
{
    /// <inheritdoc cref="IUpdatable{TResult, TEdit, TId, TVerification}.Edit(TId, TEdit, TVerification)" />
    public Task<TResult> EditAsync(TId id, TEdit editItem, TVerification verification);
}
