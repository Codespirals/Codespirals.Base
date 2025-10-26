namespace Codespirals.Base;

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
    public TResult Delete(TId id);
}
/// <inheritdoc cref="IDeletable{TResult, TId}"/>
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface IDeletable<TResult, TId, TVerification>
{
    /// <inheritdoc cref="IDeletable{TResult, TId}.Delete(TId)"/>
    /// <param name="verification">An item to verify the user of this method with.</param>
    public TResult Delete(TId id, TVerification verification);
}
/// <inheritdoc cref="IDeletable{TResult, TId}"/>
public interface IDeletableAsync<TResult, TId>
{
    /// <inheritdoc cref="IDeletable{TResult, TId}.Delete(TId)"/>
    public Task<TResult> DeleteAsync(TId id);
}
/// <inheritdoc cref="IDeletable{TResult, TId, TVerification}"/>
public interface IDeletableAsync<TResult, TId, TVerification>
{
    /// <inheritdoc cref="IDeletable{TResult, TId, TVerification}.Delete(TId, TVerification)"/>
    public Task<TResult> DeleteAsync(TId id, TVerification verification);
}
