namespace Codespirals.Base
{
    public interface IHasVisibility<TVisibility> : IHasVisibility<TVisibility, int>
        where TVisibility : IVisibility
    {

    }
    public interface IHasVisibility<TVisibility, TValue>
        where TVisibility : IVisibility<TValue>
        where TValue : IComparable
    {
        public TValue Visibility { get; }
    }
}
