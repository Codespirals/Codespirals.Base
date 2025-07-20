namespace Codespirals.Base
{
    /// <summary>
    /// The result from a searh query and all data necessary to implement pagination
    /// </summary>
    /// <typeparam name="TResult">The type of the search result items</typeparam>
    public interface ISearchResult<TSelf, TSearchParameters, TData> : IPagination<TSearchParameters>, IResultBase<TSelf, IEnumerable<TData>>
        where TSelf : ISearchResult<TSelf, TSearchParameters, TData>
        where TSearchParameters : ISearchParameters
    {
        public static abstract TSelf Ok(TSearchParameters search, IEnumerable<TData> formattedData, int totalResults);
        public static abstract TSelf Ok(TSearchParameters search, IEnumerable<TData> unformattedData);
        public static abstract TSelf Fail(TSearchParameters search, string error, int errorCode = 0);

    }
}