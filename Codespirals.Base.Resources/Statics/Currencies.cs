using Codespirals.Base.Data;

namespace Codespirals.Base
{
    public static class Currencies
    {
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
