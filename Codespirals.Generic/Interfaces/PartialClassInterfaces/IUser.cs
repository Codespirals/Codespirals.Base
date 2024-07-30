namespace Codespirals.Generic.Interfaces
{
    public interface IUser<TProfileImage, TPronouns> : IUserBase
        where TProfileImage : IImage
        where TPronouns : IPronouns
    {
        /// <summary>
        /// This user's preferred pronouns.
        /// </summary>
        public TPronouns? Pronouns { get; }
        /// <summary>
        /// The profile image this user uses. This should be a small image.
        /// </summary>
        public TProfileImage? ProfileImage { get; }
    }
}