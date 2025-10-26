namespace Codespirals.Base;

/// <summary>
/// The most basic information about a user
/// </summary>
public interface IUserBase : IUserBase<string>
{

}
/// <inheritdoc cref="IUserBase"/>
/// <typeparam name="TId">The type of the Id property</typeparam>
public interface IUserBase<TId> : IIdentifiable<TId>, IHasUsername
{

}
