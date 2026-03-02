using Codespirals.Base.Filtering;
using Codespirals.Base.Results;

namespace Codespirals.Base.CRUD;

/// <summary>
/// A service implementing this interface implements a search function
/// </summary>
/// <typeparam name="TSearchParameters">The search paramters implementing <see cref="ISearchParameters"/></typeparam>
/// <typeparam name="TSearchResult">The type of object representing the result of the operation</typeparam>
/// <typeparam name="TData">The type to return in the search results</typeparam>
public interface ISearchable<TSearchResult, TErrorCode, TData, TSearchParameters>
    where TSearchParameters : ISearchParameters
    where TSearchResult : IPaginatedResult<TSearchResult, TErrorCode, TData, TSearchParameters>
{
    /// <inheritdoc cref="ISearchable{TSearchResult, TErrorCode, TData, TSearchParameters}.Search(TSearchParameters)"/>
    TSearchResult Search(TSearchParameters search);
}
/// <inheritdoc cref="ISearchable{TSearchResult, TErrorCode, TData, TSearchParameters}"/>
/// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
public interface ISearchable<TSearchResult, TErrorCode, TData, TSearchParameters, TVerification>
    where TSearchParameters : ISearchParameters
    where TSearchResult : IPaginatedResult<TSearchResult, TErrorCode, TData, TSearchParameters>
{
    /// <inheritdoc cref="ISearchable{TSearchResult, TErrorCode, TData, TSearchParameters}.Search(TSearchParameters)"/>
    /// <param name="verification">An item to verify the user of this method with.</param>
    TSearchResult Search(TSearchParameters search, TVerification verification);
}
