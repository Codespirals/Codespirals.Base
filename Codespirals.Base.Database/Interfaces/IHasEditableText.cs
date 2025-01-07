using Codespirals.Base;

namespace Collabour.DB.EntityInterfaces
{
    public interface IHasEditableText<TEditableText, TText>
        where TEditableText : IEditableText<ITextItem>
        where TText : ITextItem
    {
        public TEditableText? EditableText { get; }
    }
}
