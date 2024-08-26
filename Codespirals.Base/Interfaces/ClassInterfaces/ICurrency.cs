namespace Codespirals.Base
{
    public interface ICurrency : ICurrencyBase
    {
        int MainUnitToMinimalRatio { get; set; }
        DateTime? RateUpdated { get; set; }
    }
}