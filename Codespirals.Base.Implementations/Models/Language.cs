using Codespirals.Base.Exceptions;
using Codespirals.Base.Implementations.Data;
using Codespirals.Sqlite.Services;
using System.Globalization;

namespace Codespirals.Base.Models
{
    public class Language : ILanguage
    {
        public string IsoCode { get; init; } = "en";
        public string Name { get; init; } = "English";

        public Language()
        {

        }
        public static Language GetLanguage(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            var dataService = new SqliteService("resources");
            if (dataService.Created)
                Data.SeedData(dataService);
            return dataService.SelectItem<Language>("Languages", nameof(IsoCode), isoCode) ?? throw new LanguageNotFoundException(isoCode);
        }
        public static Language GetLanguage(CultureInfo ci)
        {
            var end = ci.DisplayName.Contains('(') ? ci.DisplayName.IndexOf('(') : ci.DisplayName.Length;
            return new Language { IsoCode = ci.TwoLetterISOLanguageName, Name = ci.EnglishName[..end] };
        }

    }
}
