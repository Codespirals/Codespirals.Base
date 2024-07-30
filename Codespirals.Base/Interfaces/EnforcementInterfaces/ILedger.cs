namespace Codespirals.Generic.Interfaces
{
    public interface ILedger<TCurrency, TEntries> : ITotal<TCurrency>
        where TCurrency : ICurrency
        where TEntries : IMoney<TCurrency>
    {
        /// <summary>
        /// A list of <see cref="IMoneyItem"/> items
        /// </summary>
        public ICollection<TEntries> Entries { get; }
    }
}
