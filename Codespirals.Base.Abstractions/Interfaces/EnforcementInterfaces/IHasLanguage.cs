namespace Codespirals.Base
{
    public interface IHasLanguage<TLanguage>
        where TLanguage : ILanguage
    {
        public TLanguage Language { get; }
    }
}
