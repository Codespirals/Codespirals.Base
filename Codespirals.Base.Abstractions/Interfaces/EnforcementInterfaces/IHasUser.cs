namespace Codespirals.Base
{
    /// <summary>
    /// A class that implements this interface is guaranteed to have a <see cref="User"/> attached to it
    /// </summary>
    public interface IHasUser<TUser>
        where TUser : IUserBase
    {
        /// <summary>
        /// The <see cref="User"/> that has created this object
        /// </summary>
        public TUser User { get; }
    }
}
