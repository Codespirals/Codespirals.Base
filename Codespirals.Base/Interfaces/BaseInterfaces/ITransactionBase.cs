namespace Codespirals.Base
{
    public interface ITransactionBase<TCurrency, TUser> : IMoneyBase<TCurrency>, IHasUser<TUser>, ICreatable
        where TCurrency : ICurrencyBase
        where TUser : IUserBase
    {

    }
}
