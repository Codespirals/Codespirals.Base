namespace Codespirals.Base.Models
{
    internal class Currencies
    {
        private readonly Dictionary<string, Currency> _currencies = new()
        {
            ["usd"] = new() { Name = "US Dollar", Symbol = "$", IsoCode = "USD" },
            ["eur"] = new() { Name = "Euro", Symbol = "€", IsoCode = "EUR" },
            ["chf"] = new() { Name = "Swiss Franc", Symbol = "CHF", IsoCode = "CHF" },
            ["gdp"] = new() { Name = "Pound sterling", Symbol = "£", IsoCode = "GBP" },
            ["aud"] = new() { Name = "Australian Dollar", Symbol = "$", IsoCode = "AUD" },
            ["cad"] = new() { Name = "Canadian Dollar", Symbol = "$", IsoCode = "CAD" },
        };

        public Currency? GetCurrency(string isoCode)
        {
            var found = _currencies.TryGetValue(isoCode, out var currency);
            if (!found || currency == null)
                return null;
            return currency;
        }
    }
}
