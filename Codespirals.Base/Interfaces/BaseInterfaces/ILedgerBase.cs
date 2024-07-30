namespace Codespirals.Base.Interfaces
{
    public interface ILedgerBase<TCurrency, TEntries> : ITotalBase<TCurrency>
        where TCurrency : ICurrencyBase
        where TEntries : IMoneyBase<TCurrency>
    {
        /// <summary>
        /// A list of <see cref="IMoneyItem"/> items
        /// </summary>
        public ICollection<TEntries> Entries { get; }
    }
}
