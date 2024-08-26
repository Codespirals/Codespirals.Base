using System.ComponentModel.DataAnnotations;

namespace Codespirals.Base.Models
{
    public class Language : ILanguage
    {
        [Key]
        public required string IsoCode { get; set; }
        public required string Name { get; set; }
    }
}
