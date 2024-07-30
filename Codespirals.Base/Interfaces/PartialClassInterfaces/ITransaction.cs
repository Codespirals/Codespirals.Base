namespace Codespirals.Base.Interfaces
{
    public interface ITransaction<TCurrency, TUser, TProfileImage, TPronouns> : IMoney<TCurrency>, IHasUser<TUser, TProfileImage, TPronouns>, ICreatable
        where TCurrency : ICurrency
        where TUser : IUser<TProfileImage, TPronouns>
        where TProfileImage : IImage
        where TPronouns : IPronouns
    {

    }
}
