using System.ComponentModel.DataAnnotations;

namespace Codespirals.Base.Models
{
    public class Country : ICountry
    {
        [Key]
        public required string IsoCode { get; set; }
        public required string Name { get; set; }
        public string? Flag { get; set; }
    }
}
