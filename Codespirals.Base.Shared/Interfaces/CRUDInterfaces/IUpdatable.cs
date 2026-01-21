namespace Codespirals.Base.CRUD;

/// <summary>
/// Services implementing this interface make sure there are the base operations present that allow editing a resource.
/// </summary>
/// <typeparam name="TResult">The type of object representing the result of the operation</typeparam>
/// <typeparam name="TEdit">The type of the object containing all data needed to update</typeparam>
/// <typeparam name="TId">The type of the Id of the item to update</typeparam>
public interface IUpdatable<TResult, TEdit, TId>
    where TEdit : IIdentifiable<TId>
{
    /// <summary>
    /// Update an item of the defined type with the given ID
    /// </summary>
    /// <param name="id">The Id of the item to edit</param>
    /// <param name="editItem">An object of the edit class for this operation</param>
    /// <returns>The updated item.</returns>
    TResult Edit(TEdit editItem);
}
/// <inheritdoc cref="IUpdatable{TResult, TEdit, TId}" />
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
/// <typeparam name="TResult">The type of object representing the result of the operation</typeparam>
/// <typeparam name="TEdit">The type of the object containing all data needed to update</typeparam>
/// <typeparam name="TId">The type of the Id of the item to update</typeparam>
public interface IUpdatable<TResult, TEdit, TId, TVerification>
    where TEdit : IIdentifiable<TId>
{
    /// <inheritdoc cref="IUpdatable{TResult, TEdit, TId}.Edit(TId, TEdit)" />
    /// <param name="verification">An item to verify the user of this method with.</param>
    TResult Edit(TEdit editItem, TVerification verification);
}
