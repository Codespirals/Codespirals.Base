namespace Codespirals.Base
{
    /// <summary>
    /// The required properties to implement a pagination system
    /// </summary>
    public interface IPagination : ISearch
    {
        /// <summary>
        /// The total number of search results that matched the parameters
        /// </summary>
        int TotalResults { get; }
    }
}
