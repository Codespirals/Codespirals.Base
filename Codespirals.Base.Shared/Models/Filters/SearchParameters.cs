namespace Codespirals.Base.Filtering;

/// <inheritdoc cref="ISearchParameters" />
/// <param name="query">The search query.</param>
/// <param name="page">What page to return.</param>
/// <param name="limit">How many items to return.</param>
/// <param name="sort">How to sort the items. Empty means default.</param>
/// <param name="ascending">Whether to return the result in ascending or descending order.</param>
public record SearchParameters(string query = "", int page = 0, int limit = 24, string sort = "", bool ascending = false) : ISearchParameters
{
    /// <inheritdoc />
    public string Query { get; set; } = query;

    /// <inheritdoc />
    public int Page { get; set; } = page;

    /// <inheritdoc />
    public int Limit { get; set; } = limit;

    /// <inheritdoc />
    public string Sort { get; set; } = sort;

    /// <inheritdoc />
    public bool Ascending { get; set; } = ascending;
}
