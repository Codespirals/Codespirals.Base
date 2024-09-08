using Codespirals.Base.Exceptions;
using Codespirals.Base.Implementations.Data;
using Codespirals.Sqlite.Services;

namespace Codespirals.Base.Models
{
    public class Currency : ICurrency
    {
        private int _ratio = 100;
        private decimal _rate = 1;
        private DateTime? _rateUpdated = null;

        public string IsoCode { get; init; } = "USD";
        public string Name { get; init; } = "United States Dollar";
        public string Symbol { get; init; } = "$";
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
            var dataService = new SqliteService("resources");
            if (dataService.Created)
                Data.SeedData(dataService);
            return dataService.SelectItem<Currency>("Currencies", nameof(IsoCode), isoCode) ?? throw new CurrencyNotFoundException(isoCode);
        }
    }
}
