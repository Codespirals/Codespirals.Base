namespace Codespirals.Generic.Interfaces
{
    public interface ISignup : IHasUsername, IHasEmail
    {
        /// <summary>
        /// A Hashed password
        /// </summary>
        public string Password { get; }
    }
}
