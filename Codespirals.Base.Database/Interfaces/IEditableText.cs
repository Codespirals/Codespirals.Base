namespace Codespirals.Base
{
    public interface IEditableText<TTextItem>
        where TTextItem : ITextItem
    {
        public TTextItem ActiveText { get; }
        public ICollection<TTextItem> History { get; }
    }
}
