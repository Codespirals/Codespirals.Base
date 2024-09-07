using Codespirals.Base.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;
using System.Reflection;

namespace Codespirals.Base.Implementations.Data
{
    internal static class Data
    {
        internal static SqliteConnection Connect(string dbName = "resources")
        {
            var connection = new SqliteConnection($"Data Source={dbName}.db;Version=3;New=False;Compress=True;");
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                // if connection failed, create the db
                connection = new SqliteConnection($"Data Source={dbName}.db;Version=3;New=True;Compress=True;");
                connection.Open();
                SeedData(connection);
            }
            return connection;
        }

        /// <summary>
        /// Seed with some base data
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void SeedData(SqliteConnection connection)
        {
            var languages = GenerateLanguagesFromCultureInfo();
            foreach (var language in languages)
            {
                AddLanguage(connection, language);
            }

            AddCountry(connection, CreateCountryFromCultureInfo("us", "🇺🇸"));
            AddCountry(connection, CreateCountryFromCultureInfo("ch", "🇨🇭"));
            AddCountry(connection, CreateCountryFromCultureInfo("de", "🇩🇪"));
            AddCountry(connection, CreateCountryFromCultureInfo("fr", "🇫🇷"));
            AddCountry(connection, CreateCountryFromCultureInfo("es", "🇪🇸"));
            AddCountry(connection, CreateCountryFromCultureInfo("eu", "🇪🇺"));
            AddCountry(connection, CreateCountryFromCultureInfo("ua", "🇺🇦"));
            AddCountry(connection, CreateCountryFromCultureInfo("ps", "🇵🇸"));
            AddCountry(connection, CreateCountryFromCultureInfo("ca", "🇨🇦"));
            AddCountry(connection, CreateCountryFromCultureInfo("au", "🇦🇺"));

            AddCurrency(connection, new() { Name = "US Dollar", Symbol = "$", RateToUsd = 1, IsoCode = "USD" });
            AddCurrency(connection, new() { Name = "Euro", Symbol = "€", RateToUsd = 1.12m, IsoCode = "EUR" });
            AddCurrency(connection, new() { Name = "Swiss Franc", Symbol = "CHF", RateToUsd = 1.18m, IsoCode = "CHF" });
            AddCurrency(connection, new() { Name = "Pound sterling", Symbol = "£", RateToUsd = 1.32m, IsoCode = "GBP" });
            AddCurrency(connection, new() { Name = "Australian Dollar", Symbol = "$", RateToUsd = 0.68m, IsoCode = "AUD" });
            AddCurrency(connection, new() { Name = "Canadian Dollar", Symbol = "$", RateToUsd = 0.74m, IsoCode = "CAD" });
        }
        private static void AddCountry(SqliteConnection connection, Country country)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO Countries ({nameof(Country.IsoCode)}, {nameof(Country.Name)}, {nameof(Country.Flag)}) VALUES({country.IsoCode}, {country.Name}, {country.Flag});";
            command.ExecuteNonQuery();
        }
        private static Currency CreateCurrency(string isoCode, string name, string symbol)
        {
            return new Currency() { IsoCode = isoCode, Name = name, Symbol = symbol };
        }
        private static void AddCurrency(SqliteConnection connection, Currency currency)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO Currencies ({nameof(Currency.IsoCode)}, {nameof(Currency.Name)}, {nameof(Currency.Symbol)}, {nameof(Currency.MainUnitToMinimalRatio)}, {nameof(Currency.RateToUsd)}) VALUES({currency.IsoCode}, {currency.Name}, {currency.Symbol}, {currency.MainUnitToMinimalRatio}, {currency.RateToUsd});";
            command.ExecuteNonQuery();
        }
        private static void AddLanguage(SqliteConnection connection, Language language)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO Languages ({nameof(Language.IsoCode)}, {nameof(Language.Name)}) VALUES({language.IsoCode}, {language.Name});";
            command.ExecuteNonQuery();
        }

        private static void CreateTable<TTableType>(SqliteConnection connection, string tableName)
        {
            connection.Open();

            var command = connection.CreateCommand();
            PropertyInfo[] properties = typeof(TTableType).GetProperties(BindingFlags.Public);

            command.CommandText = $"CREATE TABLE {tableName} ({properties.Select(p => $"{p.Name} {TypeToSqlType<TTableType>()}")})";
            var reader = command.ExecuteReader();

            // check if table exists
            while (reader.Read())
            {
                string myreader = reader.GetString(0);
                Console.WriteLine(myreader);
            }
            reader.Close();
        }
        private static void InsertData<TData>(SqliteConnection connection, string tableName, TData data)
        {
            try
            {
                connection.Open();
                PropertyInfo[] properties = typeof(TData).GetProperties(BindingFlags.Public);

                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO {tableName} " +
                    $"({properties.Select(p => $"{p.Name}")}) " +
                    $"VALUES {properties.Select(p => $"{p.GetValue(data)}")}";
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static string TypeToSqlType<TType>(int length = 20)
        {
            switch (typeof(TType).Name)
            {
                case "string":
                    return $"VARCHAR({length})";
                case "int":
                    return "INT";
                default:
                    return $"VARCHAR({length})";
            }
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
