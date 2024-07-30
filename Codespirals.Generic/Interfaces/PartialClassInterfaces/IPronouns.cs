namespace Codespirals.Generic.Interfaces
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
        /// <summary>
        /// A shortcut for stitching the subjective and objective form together in a standardized fashion
        /// </summary>
        public string FullPronouns { get; }
    }
}