namespace Codespirals.Base
{
    /// <summary>
    /// A wrapper to get multiple possible results from a method
    /// </summary>
    /// <typeparam name="TPrimaryResult">The main type that should have the highest importance</typeparam>
    /// <typeparam name="TAlternativeResult">An alternative type</typeparam>
    public interface IAlternative<TPrimaryResult, TAlternativeResult>
    {
        /// <summary>
        /// The primary result that will be filled in the regular use case
        /// </summary>
        TPrimaryResult? PrimaryResult { get; }
        /// <summary>
        /// THe alternative result wich will be filled if an alternative case is met
        /// </summary>
        /// <remarks>The use case for this can be an error message for example</remarks>
        TAlternativeResult? AlternativeResult { get; }
    }
    /// <inheritdoc cref="IAlternative{TPrimaryResult, TAlternativeResult}"/>
    /// <typeparam name="TTertiaryResult">A third alternative type</typeparam>
    public interface IAlternative<TPrimaryResult, TAlternativeResult, TTertiaryResult> : IAlternative<TPrimaryResult, TAlternativeResult>
    {
        /// <summary>
        /// A tertiary result
        /// </summary>
        TTertiaryResult? TertiaryResult { get; }
    }
}
