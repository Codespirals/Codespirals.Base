namespace Codespirals.Base.Interfaces
{
    public interface ITransaction<TCurrency> : IIdentifiable, IMoney<TCurrency>, ICreatable
        where TCurrency : ICurrency
    {

    }
}
