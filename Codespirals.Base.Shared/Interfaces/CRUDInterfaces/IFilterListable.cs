namespace Codespirals.Base
{
    /// <summary>
    /// A service implementing this interface implements a function to retrieve a list of items filtered by certain parameters.
    /// </summary>
    /// <typeparam name="TFilter">The filter paramters implementing <see cref="IFilterParameters"/></typeparam>
    /// <typeparam name="TListResult">The type of object representing the result of the operation</typeparam>
    /// <typeparam name="TData">The type to return in the search results</typeparam>
    public interface IFilterListable<TListResult, TErrorCode, TFilter, TData>
        where TFilter : IFilterParameters
        where TListResult : IFilteredListResult<TListResult, TErrorCode, TFilter, TData>
    {
        /// <summary>
        /// Get many of the given type of item, filtered by certain parameters.
        /// </summary>
        /// <param name="filter">The filter parameters.</param>
        /// <returns>A filtered list of items of the given type <see cref="TData"/></returns>
        public TListResult GetMany(TFilter filter);
    }
    /// <inheritdoc cref="IFilterListable{TListResult, TErrorCode, TFilter, TData}"/>
    /// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
    public interface IFilterListable<TListResult, TErrorCode, TFilter, TData, TVerification>
        where TFilter : IFilterParameters
        where TListResult : IFilteredListResult<TListResult, TErrorCode, TFilter, TData>
    {
        /// <inheritdoc cref="IFilterListable{TListResult, TErrorCode, TFilter, TData}.GetMany(TFilter)"/>
        public TListResult GetMany(TFilter filter, TVerification verification);
    }

    /// <inheritdoc cref="IFilterListable{TListResult, TErrorCode, TFilter, TData}"/>
    public interface IFilterListableAsync<TListResult, TErrorCode, TFilter, TData>
        where TFilter : IFilterParameters
        where TListResult : IFilteredListResult<TListResult, TErrorCode, TFilter, TData>
    {
        /// <inheritdoc cref="IFilterListable{TListResult, TErrorCode, TFilter, TData}.GetMany(TFilter)"/>
        public Task<TListResult> GetManyAsync(TFilter search);
    }

    /// <inheritdoc cref="IFilterListable{TListResult, TErrorCode, TFilter, TData}"/>
    public interface IFilterListableAsync<TListResult, TErrorCode, TFilter, TData, TVerification>
        where TFilter : IFilterParameters
        where TListResult : IFilteredListResult<TListResult, TErrorCode, TFilter, TData>
    {
        /// <inheritdoc cref="IFilterListable{TListResult, TErrorCode, TFilter, TData, TVerification}.GetMany(TFilter, TVerification)"/>
        public Task<TListResult> GetManyAsync(TFilter search, TVerification verification);
    }
}
