namespace Codespirals.Base.Interfaces
{
    /// <summary>
    /// Anything implementing this interface has money as a property
    /// </summary>
    public interface IMoney<TCurrency> : IHasCurrency<TCurrency>
        where TCurrency : ICurrency
    {
        /// <summary>
        /// The ammount of money represented on this object
        /// </summary>
        public decimal Amount { get; }
    }
}
