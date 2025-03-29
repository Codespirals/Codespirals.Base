namespace Codespirals.Base
{
    public interface ISignupBase : IHasUsername, IHasEmail, IHasPassword
    {
        /// <inheritdoc />
        public new string UserName { get; set; }
        /// <inheritdoc />
        public new string Email { get; set; }
    }
}
