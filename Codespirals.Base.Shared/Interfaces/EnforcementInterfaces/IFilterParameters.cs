namespace Codespirals.Base
{
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
        public bool Ascending { get; }
    }
}
