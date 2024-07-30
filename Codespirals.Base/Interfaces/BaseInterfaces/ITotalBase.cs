namespace Codespirals.Base.Interfaces
{
    public interface ITotalBase<TCurrency> : IHasCurrency<TCurrency>
        where TCurrency : ICurrencyBase
    {
        /// <summary>
        /// A total that's a collection of other <see cref="IMoneyItem.Amount"/>s
        /// </summary>
        public decimal Total { get; }
    }
}
