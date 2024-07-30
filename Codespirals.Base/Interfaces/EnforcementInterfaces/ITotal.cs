namespace Codespirals.Base.Interfaces
{
    public interface ITotal<TCurrency> : IHasCurrency<TCurrency>
        where TCurrency : ICurrency
    {
        /// <summary>
        /// A total that's a collection of other <see cref="IMoneyItem.Amount"/>s
        /// </summary>
        public decimal Total { get; }
    }
}
