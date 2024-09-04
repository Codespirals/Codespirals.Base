using System.ComponentModel.DataAnnotations;

namespace Codespirals.Base.Models
{
    public class Currency : ICurrency
    {
        private int _ratio = 100;
        [Key]
        public required string IsoCode { get; set; }
        public required string Name { get; set; }
        public required string Symbol { get; set; }
        public decimal RateToUsd { get; set; }
        public DateTime? RateUpdated { get; set; }
        public int MainUnitToMinimalRatio { get { return _ratio; } set { _ratio = Math.Clamp(value, 1, int.MaxValue); } }
    }
}
