namespace Codespirals.Base
{
    public interface IHasPronouns
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