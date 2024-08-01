namespace Codespirals.Base.Interfaces
{
    /// <summary>
    /// A class that implements this interface is guaranteed to have a <see cref="User"/> attached to it
    /// </summary>
    public interface IHasUser<TUser>
        where TUser : IUserMinimalBase
    {
        /// <summary>
        /// The <see cref="User"/> that has created this object
        /// </summary>
        public TUser User { get; init; }
    }
}
