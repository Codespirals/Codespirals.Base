using Codespirals.Base.Exceptions;

namespace Codespirals.Base.Models
{
    public record Country : ICountry
    {
        public required string IsoCode { get; init; }
        public required string Name { get; init; }
        public string? Flag { get; internal set; }

        public Country()
        {

        }
        public static Country GetCountry(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            var country = new Countries().GetCountry(isoCode) ?? throw new CountryNotFoundException(isoCode);
            return country;
        }
    }
}
