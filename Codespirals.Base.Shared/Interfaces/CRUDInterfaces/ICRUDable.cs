namespace Codespirals.Base.CRUD;

/// <summary>
/// Services implementing this interface make sure there are some base operations.
/// These operations are usually used to interact with a database, but use them however you want.
/// </summary>
/// <typeparam name="TId">The type with which to identify an object. Usually <see cref="int"/> or <see cref="string"/></typeparam>
/// <typeparam name="TCreate">The creation type</typeparam>
/// <typeparam name="TResult">The type of object representing the result of a create, retrieve or update operation</typeparam>
/// <typeparam name="TEdit">The update or edit type</typeparam>
/// <typeparam name="TDeleteResult">The type of object representing the result a delete operation</typeparam>
public interface ICRUDable<TResult, TCreate, TEdit, TDeleteResult, TId> : ICreatable<TResult, TCreate>, IRetrievable<TResult, TId>, IUpdatable<TResult, TEdit, TId>, IDeletable<TDeleteResult, TId>
    where TEdit : IIdentifiable<TId>
{

}
/// <inheritdoc cref="ICRUDable{TResult, TCreate, TEdit, TDeleteResult, TId}"/>    
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface ICRUDable<TResult, TCreate, TEdit, TDeleteResult, TId, TVerification> : ICreatable<TResult, TCreate, TVerification>, IRetrievable<TResult, TId, TVerification>, IUpdatable<TResult, TEdit, TId, TVerification>, IDeletable<TDeleteResult, TId, TVerification>
    where TEdit : IIdentifiable<TId>
{

}
