namespace Codespirals.Base;

public interface IApprovable<TValue>
{
    TValue Approval { get; }
}
