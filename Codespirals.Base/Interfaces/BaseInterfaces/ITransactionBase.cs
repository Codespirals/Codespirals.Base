using Codespirals.Base.Interfaces;

namespace Codespirals.Base.Interfaces
{
    public interface ITransactionBase<TCurrency, TUser, TProfileImage, TPronouns> : IMoneyBase<TCurrency>, IHasUser<TUser, TProfileImage, TPronouns>, ICreatable
        where TCurrency : ICurrencyBase
        where TUser : IUserBase<TProfileImage, TPronouns>
        where TProfileImage : IImageBase
        where TPronouns : IPronounsBase
    {

    }
}
