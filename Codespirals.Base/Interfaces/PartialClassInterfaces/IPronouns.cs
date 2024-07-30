namespace Codespirals.Base.Interfaces
{
    public interface IPronouns : IIdentifiable
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