namespace Codespirals.Base
{
    /// <summary>
    /// A standardized query object sent to be sent to an API or similar to get a result back
    /// </summary>
    public interface ISearchParameters : IFilterParameters
    {
        /// <summary>
        /// A text query containing all the information to be filtered for
        /// How this is implemented (if at all) depends on the project
        /// </summary>
        string Query { get; }
    }
}