namespace Codespirals.Base
{
    /// <summary>
    /// A service implementing this interface implements a search function
    /// </summary>
    /// <typeparam name="TListResult">The type of object representing the result of the operation</typeparam>
    /// <typeparam name="TData">The type to return in the search results</typeparam>
    public interface IListable<TListResult, TErrorCode, TData>
        where TListResult : IListResult<TListResult, TErrorCode, TData>
    {
        /// <summary>
        /// A method to get a list of results of type <see cref="TData"/>
        /// </summary>
        /// <returns></returns>
        public TListResult GetMany();
    }

    /// <inheritdoc cref="IListable{TListResult, TErrorCode, TData}"/>
    /// <typeparam name="TVerification">A way to verify the current user has permission to use this method.</typeparam>
    public interface IListable<TListResult, TErrorCode, TData, TVerification>
        where TListResult : IListResult<TListResult, TErrorCode, TData>
    {
        /// <inheritdoc cref="IListable{TListResult, TErrorCode, TData}.GetMany()"/>
        /// <param name="verification">An item to verify the user of this method with.</param>
        public TListResult GetMany(TVerification verification);
    }

    /// <inheritdoc cref="IListable{TListResult, TErrorCode, TData}"/>
    public interface IListableAsync<TListResult, TErrorCode, TData>
        where TListResult : IListResult<TListResult, TErrorCode, TData>
    {
        /// <inheritdoc cref="IListable{TListResult, TErrorCode, TData}.GetMany()"/>
        public Task<TListResult> GetManyAsync();
    }
    /// <inheritdoc cref="IListable{TListResult, TErrorCode, TData, TVerification}"/>
    public interface IListableAsync<TListResult, TErrorCode, TData, TVerification>
        where TListResult : IListResult<TListResult, TErrorCode, TData>
    {
        /// <inheritdoc cref="IListable{TListResult, TErrorCode, TData, TVerification}.GetMany(TVerification)"/>
        public Task<TListResult> GetManyAsync(TVerification verification);
    }
}
