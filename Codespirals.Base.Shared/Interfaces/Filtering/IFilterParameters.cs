namespace Codespirals.Base.Filtering;

/// <summary>
/// A set of parameters with which to filter a list down to a more managable size
/// </summary>
public interface IFilterParameters
{
    /// <summary>
    /// What page of the search results to return
    /// </summary>
    /// <remarks>One "page" is <seealso cref="Limit"/> results long</remarks>
    int Page { get; }
    /// <summary>
    /// How many results to return at maximum (per page)
    /// </summary>
    /// <remarks>Hint: Setting this to a number divisible by 12 allows for seamless grouping on most screen sizes, as 12 can be divided into rows of 2, 3, 4 and 6</remarks>
    int Limit { get; }
    /// <summary>
    /// How to sort the results
    /// </summary>
    /// <remarks>Actual results depend on implementation.</remarks>
    string Sort { get; }
    /// <summary>
    /// Whether to get the results in ascending or descending order.
    /// </summary>
    /// <remarks>As bool defaults to <see langword="false"/> the default is descending unless otherwise specified in the implementation.</remarks>
    bool Ascending { get; }
}
