namespace Codespirals.Generic.Interfaces
{
    public interface IUserBase : IIdentifiable
    {
        /// <summary>
        /// The username of this user
        /// </summary>
        public string Username { get; }
    }
}
