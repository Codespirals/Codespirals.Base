namespace Codespirals.Base
{
    public interface IHasCurrency<TCurrency>
    {
        public TCurrency Currency { get; }
    }
}
