namespace Codespirals.Base.Interfaces
{
    /// <summary>
    /// A class that implements this interface is guaranteed to have a <see cref="User"/> attached to it
    /// </summary>
    public interface IHasUser<TUser, TProfileImage, TPronouns>
        where TUser : IUserBase<TProfileImage, TPronouns>
        where TProfileImage : IImageBase
        where TPronouns : IPronounsBase
    {
        /// <summary>
        /// The <see cref="User"/> that has created this object
        /// </summary>
        public TUser User { get; init; }
    }
}
