namespace Codespirals.Base
{

    public interface IHasVisibility<TVisibility>
        where TVisibility : IVisibility
    {
        public string Visibility { get; }
    }
}
