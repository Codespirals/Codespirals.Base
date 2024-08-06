namespace Codespirals.Base
{
    public interface IPronounsBase
    {
        /// <summary>
        /// The subjective form of these pronouns
        /// </summary>
        /// <example>He</example>
        /// <example>She</example>
        /// <example>They</example>
        public string Subjective { get; }
        /// <summary>
        /// The objective form of these pronouns
        /// </summary>
        /// <example>Him</example>
        /// <example>Her</example>
        /// <example>Them</example>
        public string Objective { get; }
    }
}