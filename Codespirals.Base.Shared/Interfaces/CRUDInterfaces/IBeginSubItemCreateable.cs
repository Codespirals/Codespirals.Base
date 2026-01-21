namespace Codespirals.Base.CRUD;

/// <summary>
/// A service implementing this interface requires the api to have a method to retrieve an object of the create type for a given class
/// </summary>
/// <typeparam name="TCreate">The create object</typeparam>
/// <remarks>
/// This interface is in almost all cases optional however implementing it makes it easy 
/// to go through all creation steps by using nothing but the service implementing this
/// </remarks>
public interface IBeginSubItemCreateable<TCreate>
{
    /// <summary>
    /// Request a create object to start creating a new item with
    /// </summary>
    /// <param name="parentId">The id of the parent item this sub item will be attached to</param>
    /// <returns>The create object</returns>
    TCreate BeginCreate(string parentId);
}
/// <inheritdoc cref="IBeginCreateable{TCreate}" />
/// <typeparam name="TCreate">The create object</typeparam>
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface IBeginSubItemCreateable<TCreate, TVerification>
{
    /// <inheritdoc cref="IBeginSubItemCreateable{TCreate}.BeginCreate(string)" />
    /// <param name="verification">An item to verify the user of this method with.</param>
    TCreate BeginCreate(string parentId, TVerification verification);
}
