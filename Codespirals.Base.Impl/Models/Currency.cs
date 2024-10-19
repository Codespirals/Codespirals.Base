using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codespirals.Base.Models
{
    [Table("Currencies")]
    public class Currency : ICurrency
    {
        private int _ratio = 100;
        private decimal _rate = 1;
        private DateTime? _rateUpdated = null;

        [Key]
        public string IsoCode { get; init; } = "usd";
        public string Name { get; init; } = "United States Dollar";
        public string Symbol { get; init; } = "$";
        public int MainUnitToMinimalRatio { get { return _ratio; } init { _ratio = Math.Clamp(value, 1, int.MaxValue); } }
        public decimal RateToUsd { get { return _rate; } set { _rateUpdated = DateTime.Now; _rate = Math.Clamp(value, (decimal)1e-10, (decimal)1e10); } }
        public DateTime? RateUpdated { get { return _rateUpdated; } }

        public Currency()
        {

        }
    }
}
