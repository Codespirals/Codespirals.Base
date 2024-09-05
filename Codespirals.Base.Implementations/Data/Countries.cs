using System.Globalization;

namespace Codespirals.Base.Models
{
    internal class Countries
    {
        private readonly Dictionary<string, Country> _countries = new()
        {
            ["us"] = CreateCountry("us", "🇺🇸"),
            ["ch"] = CreateCountry("ch", "🇨🇭"),
            ["de"] = CreateCountry("de", "🇩🇪"),
            ["fr"] = CreateCountry("fr", "🇫🇷"),
            ["es"] = CreateCountry("es", "🇪🇸"),
            ["eu"] = CreateCountry("eu", "🇪🇺"),
            ["ua"] = CreateCountry("ua", "🇺🇦"),
            ["ps"] = CreateCountry("ps", "🇵🇸"),
            ["ca"] = CreateCountry("ca", "🇨🇦"),
            ["au"] = CreateCountry("au", "🇦🇺"),
        };

        public Country? GetCountry(string isoCode)
        {
            var found = _countries.TryGetValue(isoCode, out var country);
            if (!found || country == null)
                return null;
            return country;
        }

        private static Country CreateCountry(string isoCode)
        {
            var ci = new CultureInfo($"en-{isoCode}") ?? throw new ArgumentException($"ISO code {isoCode} is not valid.");
            var country = new Country
            {
                IsoCode = isoCode,
                Name = ci.EnglishName[ci.EnglishName.IndexOf('(')..].Trim('(', ')', ' ')
            };
            return country;
        }

        private static Country CreateCountry(string isoCode, string flag)
        {
            var country = CreateCountry(isoCode);
            country.Flag = flag;
            return country;
        }
        private static Country AddFlag(string isoCode, string flag)
        {
            var country = Country.GetCountry(isoCode);
            country.Flag = flag;
            return country;
        }
    }
}
