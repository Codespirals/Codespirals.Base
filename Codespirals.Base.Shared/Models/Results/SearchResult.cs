namespace Codespirals.Base
{
    /// <summary>
    /// This model represents the results value of a method that returns a list of items.
    /// These items are filtered by a search query and can be paginated.
    /// </summary>
    /// <typeparam name="TData">The item type that was searched for</typeparam>
    /// <typeparam name="TSearchParameters">The search parameters</typeparam>
    public record SearchResult<TSearchParameters, TData> : ISearchResult<SearchResult<TSearchParameters, TData>, string, TSearchParameters, TData>
        where TSearchParameters : ISearchParameters, new()
    {
        /// <inheritdoc/>
        public TSearchParameters Parameters { get; init; }
        /// <inheritdoc/>
        public int TotalResults { get; init; }
        public bool Success { get; internal set; }
        public string Error { get; internal set; } = "";
        public string? ErrorCode { get; internal set; }
        public IEnumerable<TData> Data { get; internal set; } = [];

        private SearchResult(string error, string? errorCode = null)
        {
            Parameters = new TSearchParameters();
            Success = false;
            Error = error;
            ErrorCode = errorCode;
        }
        private SearchResult(TSearchParameters search, string error, string? errorCode = null) : this(error, errorCode)
        {
            Parameters = search;
            Success = false;
            Error = error;
            ErrorCode = errorCode;
        }
        private SearchResult(TSearchParameters search, IEnumerable<TData> formattedData, int totalResults)
        {
            Parameters = search;
            Success = true;
            TotalResults = totalResults;
            Data = formattedData.ToList();
        }
        private SearchResult(TSearchParameters search, IEnumerable<TData> unformattedData)
        {
            Parameters = search;
            Success = true;
            Data = unformattedData.ApplyFilterParameters(search, short.MaxValue, out int totalResults).ToList();
            TotalResults = totalResults;
        }
        public static SearchResult<TSearchParameters, TData> Ok(TSearchParameters search, IEnumerable<TData> formattedData, int totalResults) => new(search, formattedData, totalResults);
        public static SearchResult<TSearchParameters, TData> OkAndFormat(TSearchParameters search, IEnumerable<TData> unformattedData) => new(search, unformattedData);
        public static SearchResult<TSearchParameters, TData> Fail(string error, string? errorCode = null) => new(error, errorCode);
        public static SearchResult<TSearchParameters, TData> Fail(TSearchParameters search, string error, string? errorCode = null) => new(search, error, errorCode);
    }
}
