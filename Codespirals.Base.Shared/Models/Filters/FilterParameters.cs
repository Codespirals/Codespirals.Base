namespace Codespirals.Base.Filtering;

public class FilterParameters : IFilterParameters
{
    /// <inheritdoc />
    public int Page { get; set; }

    /// <inheritdoc />
    public int Limit { get; set; }

    /// <inheritdoc />
    public string Sort { get; set; } = "";

    /// <inheritdoc />
    public bool Ascending { get; set; }
}
