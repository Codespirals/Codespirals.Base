namespace Codespirals.Base;

public interface ISignupBase : IHasUsername, IHasEmail, IHasPassword
{
    /// <inheritdoc />
    new string UserName { get; set; }
}
