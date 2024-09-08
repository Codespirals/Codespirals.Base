using Codespirals.Base.Exceptions;
using Codespirals.Base.Implementations.Data;
using Codespirals.Sqlite.Services;

namespace Codespirals.Base.Models
{
    public class Country : ICountry
    {
        public string IsoCode { get; init; } = "ch";
        public string Name { get; init; } = "Switzerland";
        public string? Flag { get; internal set; }

        public Country()
        {

        }
        public static Country GetCountry(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            var dataService = new SqliteService("resources");
            if (dataService.Created)
                Data.SeedData(dataService);
            return dataService.SelectItem<Country>("Countries", nameof(IsoCode), isoCode) ?? throw new CountryNotFoundException(isoCode);
        }
    }
}
