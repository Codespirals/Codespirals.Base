namespace Codespirals.Base
{
    /// <summary>
    /// This model represents the results value of a method that returns a list of items.
    /// These items are filtered by a search query and can be paginated.
    /// </summary>
    /// <typeparam name="TData">The item type that was searched for</typeparam>
    /// <typeparam name="TSearch">The search parameters</typeparam>
    public record SearchResult<TSearch, TData>() : ISearchResult<TSearch, TData>
        where TSearch : ISearch, new()
    {
        /// <inheritdoc/>
        public TSearch Parameters { get; init; } = new();
        /// <inheritdoc/>
        public int TotalResults { get; init; }
        public bool Success { get; internal set; }
        public string Error { get; internal set; } = "";
        public int ErrorCode { get; internal set; }
        public List<TData> Data { get; internal set; } = [];

        private SearchResult(TSearch search) : this()
        {
            Parameters = search;
        }
        private SearchResult(TSearch search, string error, int errorCode = 0) : this(search)
        {
            Success = false;
            Error = error;
            ErrorCode = errorCode;
        }
        private SearchResult(TSearch search, List<TData> formattedData, int totalResults) : this(search)
        {
            Success = true;
            TotalResults = totalResults;
            Data = formattedData;
        }
        private SearchResult(TSearch search, List<TData> unformattedData) : this(search)
        {
            Success = true;
            Data = unformattedData.ApplySearchParameters(search, short.MaxValue, out int totalResults).ToList();
            TotalResults = totalResults;
        }
        public static SearchResult<TSearch, TData> Ok(TSearch search, List<TData> formattedData, int totalResults) => new(search, formattedData, totalResults);
        public static SearchResult<TSearch, TData> Ok(TSearch search, List<TData> unformattedData) => new(search, unformattedData);
        public static SearchResult<TSearch, TData> Fail(TSearch search, string error, int errorCode = 0) => new(search, error, errorCode);
    }
}
