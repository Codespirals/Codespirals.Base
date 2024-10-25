using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Codespirals.Base
{
    [Table("Languages")]
    public class Language : ILanguage
    {
        [Key]
        public string Id => IsoCode;
        public string IsoCode { get; init; } = "en";
        public string Name { get; init; } = "English";

        public Language()
        {
            var language = GetLanguage(new CultureInfo("en"));
            Name = language.Name;
            IsoCode = language.IsoCode;
        }
        public static Language GetLanguage(CultureInfo ci)
        {
            var end = ci.DisplayName.Contains('(') ? ci.DisplayName.IndexOf('(') : ci.DisplayName.Length;
            return new Language { IsoCode = ci.TwoLetterISOLanguageName, Name = ci.EnglishName[..end] };
        }
        public CultureInfo ToCultureInfo()
            => new(IsoCode);
    }
}
