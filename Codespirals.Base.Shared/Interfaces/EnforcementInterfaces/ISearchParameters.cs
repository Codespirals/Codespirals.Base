namespace Codespirals.Base;

/// <summary>
/// An extension on <see cref="IFilterParameters"/> with an aditional string query to filter the objects further
/// </summary>
public interface ISearchParameters : IFilterParameters
{
    /// <summary>
    /// A text query containing all the information to be filtered for
    /// How this is implemented (if at all) depends on the project
    /// </summary>
    string Query { get; }
}