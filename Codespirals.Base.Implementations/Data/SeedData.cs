using Codespirals.Base.Models;
using System.Globalization;

namespace Codespirals.Base.Data
{
    internal static class SeedData
    {
        internal static void SeedLanguages(string dbName)
        {
            using var db = new ResourceContext(dbName);
            var languages = GenerateLanguagesFromCultureInfo();
            foreach (var language in languages)
            {
                db.Languages.Add(language);
            }
            db.SaveChanges();
        }
        internal static void SeedCountries(string dbName)
        {
            using var db = new ResourceContext(dbName);
            db.Countries.Add(CreateCountryFromCultureInfo("us", "🇺🇸"));
            db.Countries.Add(CreateCountryFromCultureInfo("ch", "🇨🇭"));
            db.Countries.Add(CreateCountryFromCultureInfo("de", "🇩🇪"));
            db.Countries.Add(CreateCountryFromCultureInfo("fr", "🇫🇷"));
            db.Countries.Add(CreateCountryFromCultureInfo("es", "🇪🇸"));
            db.Countries.Add(CreateCountryFromCultureInfo("eu", "🇪🇺"));
            db.Countries.Add(CreateCountryFromCultureInfo("ua", "🇺🇦"));
            db.Countries.Add(CreateCountryFromCultureInfo("ps", "🇵🇸"));
            db.Countries.Add(CreateCountryFromCultureInfo("ca", "🇨🇦"));
            db.Countries.Add(CreateCountryFromCultureInfo("au", "🇦🇺"));

            db.SaveChanges();
        }
        internal static void SeedCurrencies(string dbName)
        {
            using var db = new ResourceContext(dbName);
            db.Currencies.Add(new Currency { Name = "United States Dollar", Symbol = "$", RateToUsd = 1, IsoCode = "usd" });
            db.Currencies.Add(new Currency { Name = "Euro", Symbol = "€", RateToUsd = 1.12m, IsoCode = "eur" });
            db.Currencies.Add(new Currency { Name = "Swiss Franc", Symbol = "CHF", RateToUsd = 1.18m, IsoCode = "chf" });
            db.Currencies.Add(new Currency { Name = "Pound sterling", Symbol = "£", RateToUsd = 1.32m, IsoCode = "gbp" });
            db.Currencies.Add(new Currency { Name = "Australian Dollar", Symbol = "$", RateToUsd = 0.68m, IsoCode = "aud" });
            db.Currencies.Add(new Currency { Name = "Canadian Dollar", Symbol = "$", RateToUsd = 0.74m, IsoCode = "cad" });

            db.SaveChanges();
        }
        // just for seeding
        private static Country CreateCountryFromCultureInfo(string isoCode, string flag)
        {
            var ci = new CultureInfo($"en-{isoCode}") ?? throw new ArgumentException($"ISO code {isoCode} is not valid.");
            string name = ci.EnglishName[ci.EnglishName.IndexOf('(')..].Trim('(', ')', ' ');
            return new Country { Name = name, IsoCode = isoCode, Flag = flag };
        }
        private static List<Language> GenerateLanguagesFromCultureInfo()
        {
            var languages = CultureInfo.GetCultures(CultureTypes.NeutralCultures).DistinctBy(l => l.TwoLetterISOLanguageName);
            var res = new List<Language>();
            foreach (var language in languages)
            {
                var end = language.DisplayName.Contains('(') ? language.DisplayName.IndexOf('(') : language.DisplayName.Length;
                res.Add(new Language { IsoCode = language.TwoLetterISOLanguageName, Name = language.EnglishName[..end] });
            }
            // discarding the first one, which is "invariant culture"
            return res.Skip(1).ToList();
        }
    }
}
