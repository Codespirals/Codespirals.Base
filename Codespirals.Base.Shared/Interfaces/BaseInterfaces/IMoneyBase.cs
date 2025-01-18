namespace Codespirals.Base
{
    /// <summary>
    /// Anything implementing this interface has money as a property
    /// </summary>
    public interface IMoneyBase<TCurrency> : IHasCurrency<TCurrency>
        where TCurrency : ICurrencyBase
    {
        /// <summary>
        /// The ammount of money represented on this object
        /// </summary>
        public decimal Amount { get; }
    }
}
