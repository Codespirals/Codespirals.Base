using Codespirals.Base.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codespirals.Base.Models
{
    [Table("Currencies")]
    public class Currency : ICurrency
    {
        private int _ratio = 100;
        private decimal _rate = 1;
        private DateTime? _rateUpdated = null;

        [Key]
        public string IsoCode { get; init; } = "usd";
        public string Name { get; init; } = "United States Dollar";
        public string Symbol { get; init; } = "$";
        public int MainUnitToMinimalRatio { get { return _ratio; } init { _ratio = Math.Clamp(value, 1, int.MaxValue); } }
        public decimal RateToUsd { get { return _rate; } private set { _rateUpdated = DateTime.Now; _rate = Math.Clamp(value, (decimal)1e-10, (decimal)1e10); } }
        public DateTime? RateUpdated { get { return _rateUpdated; } }

        public Currency()
        {

        }
        public static Currency GetCurrency(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..3].ToLowerInvariant();
            using var db = new ResourceContext("resources");
            if (!db.Currencies.Any())
                SeedData.SeedCurrencies("resources");
            return db.Currencies.FirstOrDefault(c => c.IsoCode == isoCode) ?? new Currency();
        }
        public static List<Currency> GetCurrencies()
        {
            using var db = new ResourceContext("resources");
            if (!db.Currencies.Any())
                SeedData.SeedCurrencies("resources");
            return [.. db.Currencies];
        }
        public static void UpdateRateToUsd(string isoCode, decimal rate)
        {
            using var db = new ResourceContext("resources");
            var currency = GetCurrency(isoCode);
            currency.RateToUsd = rate;
            db.Currencies.Update(currency);
            db.SaveChanges();
        }
    }
}
