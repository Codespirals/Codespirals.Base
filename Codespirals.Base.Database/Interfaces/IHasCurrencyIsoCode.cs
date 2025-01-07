namespace Codespirals.Base
{
    public interface IHasCurrencyIsoCode
    {
        /// <summary>
        /// The ISO code of the currency the money on this object is in
        /// </summary>
        public string CurrencyIsoCode { get; }
    }
}
