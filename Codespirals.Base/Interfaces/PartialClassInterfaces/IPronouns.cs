namespace Codespirals.Base.Interfaces
{
    public interface IPronouns
    {
        /// <summary>
        /// The subjective form of these pronouns (He, She, They, etc.)
        /// </summary>
        public string Subjective { get; }
        /// <summary>
        /// The objective form of these pronouns (Him, Her, Them, etc.)
        /// </summary>
        public string Objective { get; }
    }
}