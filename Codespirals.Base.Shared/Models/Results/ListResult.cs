namespace Codespirals.Base
{
    /// <summary>
    /// This model represents the results value of a method that returns a list of items.
    /// These items are filtered by a search query and can be paginated.
    /// </summary>
    /// <typeparam name="TData">The item type that was searched for</typeparam>
    /// <typeparam name="TFilterParameters">The search parameters</typeparam>
    public record ListResult<TFilterParameters, TData>() : IListResult<ListResult<TFilterParameters, TData>, TFilterParameters, TData>
        where TFilterParameters : IFilterParameters, new()
    {
        /// <inheritdoc/>
        public TFilterParameters Parameters { get; init; } = new();
        /// <inheritdoc/>
        public int TotalResults { get; init; }
        public bool Success { get; internal set; }
        public string Error { get; internal set; } = "";
        public int ErrorCode { get; internal set; }
        public IEnumerable<TData> Data { get; internal set; } = [];

        private ListResult(TFilterParameters search) : this()
        {
            Parameters = search;
        }
        private ListResult(TFilterParameters search, string error, int errorCode = 0) : this(search)
        {
            Success = false;
            Error = error;
            ErrorCode = errorCode;
        }
        private ListResult(TFilterParameters search, IEnumerable<TData> formattedData, int totalResults) : this(search)
        {
            Success = true;
            TotalResults = totalResults;
            Data = formattedData.ToList();
        }
        private ListResult(TFilterParameters search, IEnumerable<TData> unformattedData) : this(search)
        {
            Success = true;
            Data = unformattedData.ApplySearchParameters(search, short.MaxValue, out int totalResults).ToList();
            TotalResults = totalResults;
        }
        public static ListResult<TFilterParameters, TData> Ok(TFilterParameters search, IEnumerable<TData> formattedData, int totalResults) => new(search, formattedData, totalResults);
        public static ListResult<TFilterParameters, TData> Ok(TFilterParameters search, IEnumerable<TData> unformattedData) => new(search, unformattedData);
        public static ListResult<TFilterParameters, TData> Fail(TFilterParameters search, string error, int errorCode = 0) => new(search, error, errorCode);
    }
}
