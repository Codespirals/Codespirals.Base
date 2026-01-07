namespace Codespirals.Base.Filtering;

/// <inheritdoc cref="IFilterParameters"/>
public record FilterParameters() : IFilterParameters
{
    /// <inheritdoc />
    public int Page { get; set; }

    /// <inheritdoc />
    public int Limit { get; set; }

    /// <inheritdoc />
    public string Sort { get; set; } = string.Empty;

    /// <inheritdoc />
    public bool Ascending { get; set; }

    /// <inheritdoc cref="IFilterParameters"/>
    /// <param name="page">What page to return.</param>
    /// <param name="limit">How many items to return. Default is 24.</param>
    /// <param name="sort">How to sort the items. Empty means default.</param>
    /// <param name="ascending">Whether to return the result in ascending or descending order.</param>
    public FilterParameters(int page = 0, int limit = 24, string sort = "", bool ascending = false) : this()
    {
        Page = page;
        Limit = limit;
        Sort = sort;
        Ascending = ascending;
    }
}
