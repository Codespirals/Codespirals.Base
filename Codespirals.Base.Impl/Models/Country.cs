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
    }
}
