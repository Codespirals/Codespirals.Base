namespace Codespirals.Base
{
    public interface IUserBase : IIdentifiable, IHasUsername
    {
        /// <summary>
        /// A set of personal pronouns
        /// </summary>
        /// <example>He/Him</example>
        /// <example>She/Her</example>
        /// <example>They/Them</example>
        public string? Pronouns { get; }
    }
}
