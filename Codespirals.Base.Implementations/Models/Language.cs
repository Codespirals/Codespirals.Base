using Codespirals.Base.Exceptions;
using System.Globalization;

namespace Codespirals.Base.Models
{
    public record Language : ILanguage
    {
        public required string IsoCode { get; init; }
        public required string Name { get; init; }

        public Language()
        {

        }
        public static Language GetLanguage(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            var ci = new CultureInfo(isoCode) ?? throw new LanguageNotFoundException(isoCode);
            var end = ci.DisplayName.Contains('(') ? ci.DisplayName.IndexOf('(') : ci.DisplayName.Length;
            return new Language { IsoCode = ci.TwoLetterISOLanguageName, Name = ci.EnglishName[..end] };
        }
    }
}
