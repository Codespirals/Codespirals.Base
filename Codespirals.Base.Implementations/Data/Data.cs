using Codespirals.Base.Models;
using Codespirals.Sqlite.Services;
using System.Globalization;

namespace Codespirals.Base.Implementations.Data
{
    internal static class Data
    {
        /// <summary>
        /// Seed with some base data
        /// </summary>
        /// <param name="modelBuilder"></param>
        internal static void SeedData(SqliteService service)
        {
            var languageTableName = "Languages";
            service.CreateTable<Language>(languageTableName);
            var countryTableName = "Countries";
            service.CreateTable<Country>(countryTableName);
            var currencyTableName = "Currencies";
            service.CreateTable<Currency>(currencyTableName);

            var languages = GenerateLanguagesFromCultureInfo();
            foreach (var language in languages)
            {
                service.InsertItem(languageTableName, language);
            }

            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("us", "🇺🇸"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("us", "🇺🇸"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("ch", "🇨🇭"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("de", "🇩🇪"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("fr", "🇫🇷"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("es", "🇪🇸"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("eu", "🇪🇺"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("ua", "🇺🇦"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("ps", "🇵🇸"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("ca", "🇨🇦"));
            service.InsertItem(countryTableName, CreateCountryFromCultureInfo("au", "🇦🇺"));

            service.InsertItem(countryTableName, new Currency { Name = "US Dollar", Symbol = "$", RateToUsd = 1, IsoCode = "USD" });
            service.InsertItem(countryTableName, new Currency { Name = "Euro", Symbol = "€", RateToUsd = 1.12m, IsoCode = "EUR" });
            service.InsertItem(countryTableName, new Currency { Name = "Swiss Franc", Symbol = "CHF", RateToUsd = 1.18m, IsoCode = "CHF" });
            service.InsertItem(countryTableName, new Currency { Name = "Pound sterling", Symbol = "£", RateToUsd = 1.32m, IsoCode = "GBP" });
            service.InsertItem(countryTableName, new Currency { Name = "Australian Dollar", Symbol = "$", RateToUsd = 0.68m, IsoCode = "AUD" });
            service.InsertItem(countryTableName, new Currency { Name = "Canadian Dollar", Symbol = "$", RateToUsd = 0.74m, IsoCode = "CAD" });
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
            return res;
        }
    }
}
