namespace Codespirals.Base
{
    public interface ISignupBase : IHasUsername, IHasEmail, IHasPassword
    {
        public new string UserName { get; set; }
        public new string Email { get; set; }
    }
}
