namespace Codespirals.Generic.Interfaces
{
    public interface ILogin : ISignup
    {
        /// <summary>
        /// If the user wants to stay logged in
        /// </summary>
        public bool StayLoggedIn { get; }
    }
}
