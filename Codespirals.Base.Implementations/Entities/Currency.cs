using Codespirals.Base.Exceptions;

namespace Codespirals.Base.Models
{
    public class Currency : ICurrency
    {
        private int _ratio = 100;
        private decimal _rate = 1;
        private DateTime? _rateUpdated = null;

        public required string IsoCode { get; init; }
        public required string Name { get; init; }
        public required string Symbol { get; init; }
        public int MainUnitToMinimalRatio { get { return _ratio; } init { _ratio = Math.Clamp(value, 1, int.MaxValue); } }
        public decimal RateToUsd { get { return _rate; } set { _rateUpdated = DateTime.Now; _rate = Math.Clamp(value, (decimal)1e-10, (decimal)1e10); } }
        public DateTime? RateUpdated { get { return _rateUpdated; } }

        public Currency()
        {

        }
        public static Currency GetCurrency(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..3].ToLowerInvariant();
            var currency = new Currencies().GetCurrency(isoCode) ?? throw new CurrencyNotFoundException(isoCode);
            return currency;
        }
    }
}
