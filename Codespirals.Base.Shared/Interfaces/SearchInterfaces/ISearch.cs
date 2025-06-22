namespace Codespirals.Base
{
    /// <summary>
    /// A standardized query object sent to be sent to an API or similar to get a result back
    /// </summary>
    public interface ISearch
    {
        /// <summary>
        /// A text query containing all the information to be filtered for
        /// </summary>
        string Query { get; }
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
        /// <remarks>The IDs of the items implemented by a <see cref="ISortingTypes{TValue}"/> class are the values used by codespirals algorithms, 
        /// but feel free to write your own algorithms and values</remarks>
        string Sort { get; }
        /// <summary>
        /// Whether to get the results in ascending or descending order.
        /// </summary>
        /// <remarks>As bool defaults to <see langword="false"/> the default is descending unless otherwise specified in the implementation.</remarks>
        public bool Ascending { get; }
    }
}