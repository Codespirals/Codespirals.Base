namespace Codespirals.Base
{
    public interface IUserBase<TProfileImage, TPronouns> : IUserMinimalBase
        where TProfileImage : IImageBase
        where TPronouns : IPronounsBase
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