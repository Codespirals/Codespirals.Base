using Codespirals.Base.Data;
using Codespirals.Base.Models;

namespace Codespirals.Base
{
    public static class Countries
    {
        public static Country GetCountry(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            using var db = new ResourceContext("resources");
            if (!db.Countries.Any())
                SeedData.SeedCountries("resources");
            return db.Countries.FirstOrDefault(c => c.IsoCode == isoCode) ?? new Country();
        }
        public static List<Country> GetCountries()
        {
            using var db = new ResourceContext("resources");
            if (!db.Countries.Any())
                SeedData.SeedCountries("resources");
            return [.. db.Countries];
        }
    }
}
