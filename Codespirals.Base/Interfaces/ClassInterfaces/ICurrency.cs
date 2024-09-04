namespace Codespirals.Base
{
    public interface ICurrency : ICurrencyBase
    {
        /// <summary>
        /// The ratio of the smalles possible currency version (cents) to the main unit (dollars)
        /// </summary>
        /// <example>USD Dollar to cents: 100</example>
        /// <example>TND Dinar to Millimes: 1000</example>
        /// <example>CNY Yuan to Jiao: 10</example>
        int MainUnitToMinimalRatio { get; set; }
        DateTime? RateUpdated { get; set; }
    }
}