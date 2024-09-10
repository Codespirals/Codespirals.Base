namespace Codespirals.Base
{
    public interface ITransactionBase<TCurrency> : IMoneyBase<TCurrency>, ICreatable, IHasStatus
        where TCurrency : ICurrencyBase
    {

    }
}
