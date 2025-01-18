namespace Codespirals.Base
{
    public interface IHasLanguage<TLanguage>
        where TLanguage : ILanguageBase
    {
        public TLanguage Language { get; }
    }
}
