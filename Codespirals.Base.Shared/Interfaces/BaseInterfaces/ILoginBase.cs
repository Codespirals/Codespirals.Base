namespace Codespirals.Base
{
    public interface ILoginBase : ISignupBase
    {
        /// <summary>
        /// If the user wants to stay logged in
        /// </summary>
        public bool StayLoggedIn { get; }
    }
}
