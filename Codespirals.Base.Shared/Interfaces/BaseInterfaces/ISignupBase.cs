namespace Codespirals.Base;

public interface ISignupBase : IHasUsername, IHasEmail, IHasPassword
{
    /// <inheritdoc />
    public new string UserName { get; set; }
}
