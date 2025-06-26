namespace Codespirals.Base
{
    /// <summary>
    /// Services implementing this interface make sure there are some base operations.
    /// These operations are usually used to interact with a database, but use them however you want.
    /// </summary>
    /// <typeparam name="TCreate">The creation type</typeparam>
    /// <typeparam name="TReturn">The read or get type</typeparam>
    /// <typeparam name="TEdit">The update or edit type</typeparam>
    /// <typeparam name="TDeleteReturn">What's expected to be returned by a delete call</typeparam>
    public interface ICRUDable<TReturn, TCreate, TEdit, TDeleteReturn, TId> : ICreatable<TReturn, TCreate>, IRetrievable<TReturn, TId>, IUpdatable<TReturn, TEdit>, IDeletable<TDeleteReturn, TId>
    {

    }
    /// <inheritdoc/>
    public interface ICRUDableAsync<TReturn, TCreate, TEdit, TDeleteReturn, TId> : ICreatableAsync<TReturn, TCreate>, IRetrievableAsync<TReturn, TId>, IUpdatableAsync<TReturn, TEdit>, IDeletableAsync<TDeleteReturn, TId>
    {

    }
}
