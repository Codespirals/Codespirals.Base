namespace Codespirals.Base
{
    /// <summary>
    /// A wrapper to get multiple possible options as a return from a method
    /// </summary>
    /// <typeparam name="TPrimary">The main type that should have the highest importance</typeparam>
    /// <typeparam name="TAlternative">An alternative type</typeparam>
    public interface IAlternative<TPrimary, TAlternative>
    {
        /// <summary>
        /// The primary option that will be filled in the regular use case
        /// </summary>
        TPrimary? Primary { get; }
        /// <summary>
        /// THe alternative option wich will be filled if an alternative case is met
        /// </summary>
        /// <remarks>The use case for this can be an error message for example</remarks>
        TAlternative? Alternative { get; }
    }
    /// <inheritdoc cref="IAlternative{TPrimary, TAlternative}"/>
    /// <typeparam name="TTertiary">A third alternative type</typeparam>
    public interface IAlternative<TPrimary, TSecondary, TTertiary> : IAlternative<TPrimary, TSecondary>
    {
        /// <summary>
        /// A tertiary option
        /// </summary>
        TTertiary? Tertiary { get; }
    }
}
