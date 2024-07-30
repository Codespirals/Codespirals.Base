namespace Codespirals.Base.Interfaces
{
    /// <summary>
    /// A class that implements this interface is guaranteed to have a <see cref="User"/> attached to it
    /// </summary>
    public interface IHasUser<TUser, TProfileImage, TPronouns>
        where TUser : IUser<TProfileImage, TPronouns>
        where TProfileImage : IImage
        where TPronouns : IPronouns
    {
        /// <summary>
        /// The <see cref="User"/> that has created this object
        /// </summary>
        public TUser User { get; init; }
    }
}
