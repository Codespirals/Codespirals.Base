namespace Codespirals.Base
{
    /// <summary>
    /// This model represents the results value of a method that returns a list of items.
    /// These items are filtered by a search query and can be paginated.
    /// </summary>
    /// <typeparam name="TData">The item type that was searched for</typeparam>
    /// <typeparam name="TSearchParameters">The search parameters</typeparam>
    public record SearchResult<TSearchParameters, TData>() : ISearchResult<SearchResult<TSearchParameters, TData>, TSearchParameters, TData>
        where TSearchParameters : ISearchParameters, new()
    {
        /// <inheritdoc/>
        public TSearchParameters Parameters { get; init; } = new();
        /// <inheritdoc/>
        public int TotalResults { get; init; }
        public bool Success { get; internal set; }
        public string Error { get; internal set; } = "";
        public int ErrorCode { get; internal set; }
        public IEnumerable<TData> Data { get; internal set; } = [];

        private SearchResult(TSearchParameters search) : this()
        {
            Parameters = search;
        }
        private SearchResult(TSearchParameters search, string error, int errorCode = 0) : this(search)
        {
            Success = false;
            Error = error;
            ErrorCode = errorCode;
        }
        private SearchResult(TSearchParameters search, IEnumerable<TData> formattedData, int totalResults) : this(search)
        {
            Success = true;
            TotalResults = totalResults;
            Data = formattedData.ToList();
        }
        private SearchResult(TSearchParameters search, IEnumerable<TData> unformattedData) : this(search)
        {
            Success = true;
            Data = unformattedData.ApplySearchParameters(search, short.MaxValue, out int totalResults).ToList();
            TotalResults = totalResults;
        }
        public static SearchResult<TSearchParameters, TData> Ok(TSearchParameters search, IEnumerable<TData> formattedData, int totalResults) => new(search, formattedData, totalResults);
        public static SearchResult<TSearchParameters, TData> Ok(TSearchParameters search, IEnumerable<TData> unformattedData) => new(search, unformattedData);
        public static SearchResult<TSearchParameters, TData> Fail(TSearchParameters search, string error, int errorCode = 0) => new(search, error, errorCode);
    }
}
