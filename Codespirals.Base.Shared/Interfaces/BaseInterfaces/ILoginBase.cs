namespace Codespirals.Base
{
    public interface ILoginBase : IHasPassword
    {
        public string UserNameOrEmail { get; set; }
        /// <summary>
        /// If the user wants to stay logged in
        /// </summary>
        public bool StayLoggedIn { get; }
    }
}
