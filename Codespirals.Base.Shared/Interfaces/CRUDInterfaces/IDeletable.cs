namespace Codespirals.Base.CRUD;

/// <summary>
/// Services implementing this interface make sure there are the base operations present that allow deleting a resource.
/// </summary>
/// <typeparam name="TResult">The type of object representing the result of the operation</typeparam>
/// <typeparam name="TId">The id of the item to delete</typeparam>
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
    TResult Delete(TId id);
}
/// <inheritdoc cref="IDeletable{TResult, TId}"/>
/// <typeparam name="TResult">The type of object representing the result of the operation</typeparam>
/// <typeparam name="TId">The id of the item to delete</typeparam>
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface IDeletable<TResult, TId, TVerification>
{
    /// <inheritdoc cref="IDeletable{TResult, TId}.Delete(TId)"/>
    /// <param name="id">The id of the object to delete</param>
    /// <param name="verification">An item to verify the user of this method with.</param>
    TResult Delete(TId id, TVerification verification);
}
