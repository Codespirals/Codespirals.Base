namespace Codespirals.Base
{
    public static class SelectableExtensions
    {
        public static bool Is<TSelectable>(this TSelectable primary, TSelectable other)
        where TSelectable : ISelectableBase
            => primary.Id == other.Id;

        public static bool Is<TSelectable>(this TSelectable primary, params TSelectable[] others)
        where TSelectable : ISelectableBase
            => others.Any(s => s.Id == primary.Id);
    }
}
