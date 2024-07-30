namespace Codespirals.Base.Interfaces
{
    public interface ITransaction<TCurrency> : IMoney<TCurrency>, ICreatable
        where TCurrency : ICurrency
    {

    }
}
