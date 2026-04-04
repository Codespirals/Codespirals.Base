namespace Codespirals.Base.CRUD;

/// <summary>
/// Services implementing this interface make sure there are the base operations present that allow creating a resource.
/// </summary>
/// <typeparam name="TResult"></typeparam>
/// <typeparam name="TCreate">The type containing all the information needed to create a new object</typeparam>
public interface ICreatable<TResult, TCreate>
{
    /// <summary>
    /// Create an item of the defined type
    /// </summary>
    /// <param name="createItem">An object of the creation class for this type</param>
    /// <returns>The newly created item</returns>
    TResult Create(TCreate createItem);
}
/// <inheritdoc cref="ICreatable{TResult, TCreate}"/>
/// <typeparam name="TResult"></typeparam>
/// <typeparam name="TCreate">The type containing all the information needed to create a new object</typeparam>
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface ICreatable<TResult, TCreate, TVerification>
{
    /// <inheritdoc cref="ICreatable{TResult, TCreate}.Create(TCreate)"/>
    /// <param name="createItem">An item of the creation type with all the information needed to create a new item of the result type</param>
    /// <param name="verification">An item to verify the user of this method with.</param>
    TResult Create(TCreate createItem, TVerification verification);
}
