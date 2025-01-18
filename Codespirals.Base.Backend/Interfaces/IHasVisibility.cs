namespace Codespirals.Base
{

    public interface IHasVisibility<TVisibility, TVisibilityValue>
        where TVisibility : IVisibility<TVisibilityValue>
        where TVisibilityValue : ISelectableBase
    {
        public TVisibilityValue Visibility { get; }
    }
}
