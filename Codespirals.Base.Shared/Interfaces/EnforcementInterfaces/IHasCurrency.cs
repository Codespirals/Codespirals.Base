namespace Codespirals.Base;

public interface IHasCurrency<TCurrency>
{
    TCurrency Currency { get; }
}
