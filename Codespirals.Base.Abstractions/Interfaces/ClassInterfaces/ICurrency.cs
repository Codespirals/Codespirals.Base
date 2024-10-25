namespace Codespirals.Base
{
    public interface ICurrency : ICurrencyBase, IIdentifiable
    {
        /// <summary>
        /// The ratio of the smalles possible currency version (cents) to the main unit (dollars)
        /// </summary>
        /// <remarks>
        /// Examples:<br />
        /// USD Dollar to cents: 100<br />
        /// TND Dinar to Millimes: 1000<br />
        /// CNY Yuan to Jiao: 10
        /// </remarks>
        int MainUnitToMinimalRatio { get; }
        /// <summary>
        /// An approximate rate to the US dollar
        /// </summary>
        /// <remarks>
        /// This is only for display purposes and we do not guarantee conversions at this rate.
        /// The real rate will be set by the payment processor and may therfore fluctuate.<br />
        /// Check <see cref="RateUpdated"/> to see when it was last updated
        /// </remarks>
        public decimal RateToUsd { get; }
        DateTime? RateUpdated { get; }
    }
}