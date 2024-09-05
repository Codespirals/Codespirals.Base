namespace Codespirals.Base
{
    public interface ICurrencyBase : INameable, IHasIsoCode
    {
        /// <summary>
        /// The symbol the currency uses
        /// </summary>
        /// <example>$</example>
        /// <example>£</example>
        public string Symbol { get; }
    }
}
