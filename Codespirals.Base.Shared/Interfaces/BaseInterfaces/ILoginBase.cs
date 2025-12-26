namespace Codespirals.Base;

public interface ILoginBase : IHasPassword
{
    /// <summary>
    /// The username or email of the person logging in
    /// </summary>
    string UserNameOrEmail { get; set; }
    /// <summary>
    /// If the user wants to stay logged in
    /// </summary>
    bool StayLoggedIn { get; set; }
}
