namespace Codespirals.Base.Interfaces
{
    public interface ICurrencyBase : INameable
    {
        /// <summary>
        /// An approximate rate to the US dollar
        /// </summary>
        /// <remarks>
        /// This is only for display purposes and we can't guarantee conversions at this rate.
        /// The real rate will be set by the payment processor and may therfore fluctuate.
        /// </remarks>
        public decimal RateToDollar { get; }
        /// <summary>
        /// The symbol the currency uses
        /// </summary>
        /// <example>$</example>
        /// <example>£</example>
        public string Symbol { get; }
    }
}
