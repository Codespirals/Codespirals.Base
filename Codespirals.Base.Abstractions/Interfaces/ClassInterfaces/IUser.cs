namespace Codespirals.Base
{
    public interface IUser<TProfileImage> : IUserBase, IHasPonouns
        where TProfileImage : IImageBase
    {
        /// <summary>
        /// The profile image this user uses. This should be a small image.
        /// </summary>
        public TProfileImage? ProfileImage { get; }
    }
}