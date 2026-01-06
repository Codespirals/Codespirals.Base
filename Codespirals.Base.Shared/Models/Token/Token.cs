namespace Codespirals.Base;

/// <inheritdoc cref="ITokenBase"/>
public record Token : ITokenBase
{
    private bool _isValid = true;
    /// <inheritdoc />
    public required string Key { get; init; }
    /// <inheritdoc />
    public string Value { get; init; } = Guid.NewGuid().ToString();
    /// <inheritdoc />
    public int? MinutesToLive { get; init; }
    /// <inheritdoc />
    public DateTime Created { get; init; } = DateTime.UtcNow;

    /// <inheritdoc />
    public bool IsValid
    {
        get => _isValid && (MinutesToLive is null || DateTime.UtcNow <= Created.AddMinutes((double)MinutesToLive));
        set { _isValid = value; }
    }
    /// <inheritdoc cref="ITokenBase"/>
    public Token()
    {

    }
}
