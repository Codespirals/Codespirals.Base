namespace Codespirals.Base;

public interface IHasUsername
{
    /// <summary>
    /// An application unique name of a user
    /// </summary>
    /// <remarks>Formatted as "UserName" and nullable to conformm with the .Net implementation of IdentityUser</remarks>
    public string? UserName { get; }
}
