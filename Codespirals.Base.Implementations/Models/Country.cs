using Codespirals.Base.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codespirals.Base.Models
{
    [Table("Countries")]
    public class Country : ICountry
    {
        [Key]
        public string IsoCode { get; init; } = "ch";
        public string Name { get; init; } = "Switzerland";
        public string? Flag { get; internal set; } = "🇨🇭";

        public Country()
        {

        }
        public static Country GetCountry(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            using var db = new ResourceContext("resources");
            if (!db.Countries.Any())
                SeedData.SeedCountries("resources");
            return db.Countries.FirstOrDefault(c => c.IsoCode == isoCode) ?? new Country();
        }
    }
}
