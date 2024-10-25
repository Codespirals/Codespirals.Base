using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codespirals.Base
{
    [Table("Countries")]
    public class Country : ICountry
    {
        [Key]
        public string Id => IsoCode;
        public string IsoCode { get; init; } = "ch";
        public string Name { get; init; } = "Switzerland";
        public string? Flag { get; set; } = "🇨🇭";

        public Country()
        {

        }
    }
}
