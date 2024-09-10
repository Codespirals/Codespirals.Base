using Codespirals.Base.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Reflection.Metadata;

namespace Codespirals.Base.Models
{
    [Table("Languages")]
    public class Language : ILanguage
    {
        [Key]
        public string IsoCode { get; init; } = "en";
        public string Name { get; init; } = "English";

        public Language()
        {

        }
        public static Language GetLanguage(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            using var db = new ResourceContext("resources");
            if (!db.Languages.Any())
                SeedData.SeedLanguages("resources");
            return db.Languages.FirstOrDefault(l => l.IsoCode == isoCode) ?? new Language();
        }
        public static Language GetLanguage(CultureInfo ci)
        {
            var end = ci.DisplayName.Contains('(') ? ci.DisplayName.IndexOf('(') : ci.DisplayName.Length;
            return new Language { IsoCode = ci.TwoLetterISOLanguageName, Name = ci.EnglishName[..end] };
        }
        public static List<Language> GetLanguages()
        {
            using var db = new ResourceContext("resources");
            if (!db.Languages.Any())
                SeedData.SeedLanguages("resources");
            return [.. db.Languages];
        }
    }
}
