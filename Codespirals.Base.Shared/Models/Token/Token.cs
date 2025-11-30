namespace Codespirals.Base;

public record Token : ITokenBase
{
    private bool _isValid = true;
    public required string Key { get; init; }
    public string Value { get; init; } = Guid.NewGuid().ToString();
    public int? MinutesToLive { get; init; }
    public DateTime Created { get; init; } = DateTime.UtcNow;

    public bool IsValid
    {
        get => _isValid && (MinutesToLive is null || DateTime.UtcNow <= Created.AddMinutes((double)MinutesToLive));
        set { _isValid = value; }
    }
    public Token()
    {

    }
}
