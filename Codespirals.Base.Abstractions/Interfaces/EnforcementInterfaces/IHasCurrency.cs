namespace Codespirals.Base
{
    public interface IHasCurrency<TCurrency>
        where TCurrency : ICurrencyBase
    {
        /// <summary>
        /// The <see cref="Currency"/> the money on this object is in
        /// </summary>
        public TCurrency Currency { get; }
    }
}
