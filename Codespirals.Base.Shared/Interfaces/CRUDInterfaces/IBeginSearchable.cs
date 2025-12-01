using Codespirals.Base.Filtering;

namespace Codespirals.Base.CRUD;

/// <summary>
/// A service implementing this interface requires the api to have a method to retrieve an object containing all data needed to start a search
/// </summary>
/// <typeparam name="TSearch">The type of the search object</typeparam>
/// <remarks>
/// This interface is in almost all cases optional however implementing it makes it easy 
/// to go through all creation steps by using nothing but the service implementing this
/// </remarks>
public interface IBeginSearchable<TSearch>
    where TSearch : ISearchParameters
{
    /// <summary>
    /// Request a search object to start searching with
    /// </summary>
    /// <returns>The search object</returns>
    public TSearch BeginSearch();
}

/// <inheritdoc cref="IBeginSearchable{TSearch}" />
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface IBeginSearchable<TSearch, TVerification>
    where TSearch : ISearchParameters
{
    /// <inheritdoc cref="IBeginSearchable{TSearch}.BeginSearch()" />
    /// <param name="verification">An item to verify the user of this method with.</param>
    public TSearch BeginSearch(TVerification verification);
}
/// <inheritdoc cref="IBeginSearchable{TSearch}" />
public interface IBeginSearchableAsync<TSearch>
    where TSearch : ISearchParameters
{
    /// <inheritdoc cref="IBeginSearchable{TSearch}.BeginSearch()" />
    public Task<TSearch> BeginSearchAsync();
}
/// <inheritdoc cref="IBeginSearchable{TSearch, TVerification}" />
public interface IBeginSearchableAsync<TSearch, TVerification>
    where TSearch : ISearchParameters
{
    /// <inheritdoc cref="IBeginSearchable{TSearch, TVerification}.BeginSearch(TVerification)" />
    public Task<TSearch> BeginSearchAsync(TVerification verification);
}
