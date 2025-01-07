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
        string Query { get; set; }
        /// <summary>
        /// What page of the search results to return
        /// </summary>
        /// <remarks>One "page" is <seealso cref="Limit"/> results long</remarks>
        int Page { get; set; }
        /// <summary>
        /// How many results to return at maximum (per page)
        /// </summary>
        int Limit { get; set; }
        /// <summary>
        /// How to sort the results
        /// </summary>
        /// <remarks>What the actual values will be is up to the app using this</remarks>
        string Sort { get; set; }
    }
}