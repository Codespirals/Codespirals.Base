namespace Codespirals.Base
{
    /// <summary>
    /// The result from a searh query and all data necessary to implement pagination
    /// </summary>
    /// <typeparam name="TResult">The type of the search result items</typeparam>
    public interface IListResult<TSelf, TFilterParameters, TData> : IPagination<TFilterParameters>, IResultBase<TSelf, IEnumerable<TData>>
        where TSelf : IListResult<TSelf, TFilterParameters, TData>
        where TFilterParameters : IFilterParameters
    {
        public static abstract TSelf Ok(TFilterParameters search, IEnumerable<TData> formattedData, int totalResults);
        public static abstract TSelf Ok(TFilterParameters search, IEnumerable<TData> unformattedData);
        public static abstract TSelf Fail(TFilterParameters search, string error, int errorCode = 0);

    }
}