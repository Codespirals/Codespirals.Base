namespace Codespirals.Base.CRUD;

/// <summary>
/// A service implementing this interface requires the api to have a method to retrieve an object of the create type for a given class
/// </summary>
/// <typeparam name="TCreate">The create object</typeparam>
/// <remarks>
/// This interface is in almost all cases optional however implementing it makes it easy 
/// to go through all creation steps by using nothing but the service implementing this
/// </remarks>
public interface IBeginCreateable<TCreate>
{
    /// <summary>
    /// Request a create object to start creating a new item with
    /// </summary>
    /// <returns>The create object</returns>
    public TCreate BeginCreate();
}
/// <inheritdoc cref="IBeginCreateable{TCreate}" />
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface IBeginCreateable<TCreate, TVerification>
{
    /// <inheritdoc cref="IBeginCreateable{TCreate}.BeginCreate()" />
    /// <param name="verification">An item to verify the user of this method with.</param>
    public TCreate BeginCreate(TVerification verification);
}
/// <inheritdoc cref="IBeginCreateable{TCreate}" />
public interface IBeginCreateableAsync<TCreate>
{
    /// <inheritdoc cref="IBeginCreateable{TCreate}.BeginCreate()" />
    public Task<TCreate> BeginCreateAsync();
}
/// <inheritdoc cref="IBeginCreateable{TCreate, TVerification}" />
public interface IBeginCreateableAsync<TCreate, TVerification>
{
    /// <inheritdoc cref="IBeginCreateable{TCreate, TVerification}.BeginCreate(TVerification)" />
    public Task<TCreate> BeginCreateAsync(TVerification verification);
}
