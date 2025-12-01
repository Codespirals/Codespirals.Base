namespace Codespirals.Base.CRUD;

/// <summary>
/// Services implementing this interface make sure there are the base operations present that allow retrieving or generating an object for editing a resource.
/// </summary>
/// <typeparam name="TEdit">The edit object</typeparam>
/// <typeparam name="TId">The id of the object to edit</typeparam>
/// <remarks>
/// This interface is in almost all cases optional however implementing it makes it easy 
/// to go through all creation steps by using nothing but the service implementing this
/// </remarks>
public interface IBeginUpatable<TEdit, TId>
{
    /// <summary>
    /// Get an object of the edit model for an item to begin editing it
    /// </summary>
    /// <param name="id">The Id of the item</param>
    /// <returns>The object of the edit model type</returns>
    public TEdit BeginEdit(TId id);
}
/// <inheritdoc cref="IBeginUpatable{TEdit, TId}" />
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface IBeginUpatable<TEdit, TId, TVerification>
{
    /// <inheritdoc cref="IBeginUpatable{TEdit, TId}.BeginEdit(TId)" />
    /// <param name="verification">An item to verify the user of this method with.</param>
    public TEdit BeginEdit(TId id, TVerification verification);
}
/// <inheritdoc cref="IBeginUpatable{TEdit, TId}" />
public interface IBeginUpatableAsync<TEdit, TId>
{
    /// <inheritdoc cref="IBeginUpatable{TEdit, TId}.BeginEdit(TId)" />
    public Task<TEdit> BeginEditAsync(TId id);
}
/// <inheritdoc cref="IBeginUpatable{TEdit, TId, TVerification}" />
public interface IBeginUpatableAsync<TEdit, TId, TVerification>
{
    /// <inheritdoc cref="IBeginUpatable{TEdit, TId, TVerification}.BeginEdit(TId, TVerification)" />
    public Task<TEdit> BeginEditAsync(TId id, TVerification verification);
}
