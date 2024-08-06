namespace Codespirals.Base
{
    /// <summary>
    /// Unifying Currency in its own interface removes ambiguity
    /// from items that use both <seealso cref="ITotal"/> and <seealso cref="IMoneyItem"/> interfaces
    /// </summary>
    public interface IHasCurrency<TCurrency>
        where TCurrency : ICurrencyBase
    {
        /// <summary>
        /// The <see cref="Currency"/> the money on this object is in
        /// </summary>
        public TCurrency Currency { get; }
    }
}
