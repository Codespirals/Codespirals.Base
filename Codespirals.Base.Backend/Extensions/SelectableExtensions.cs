namespace Codespirals.Base
{
    public static class SelectableExtensions
    {
        public static bool Is<TSelectable>(this TSelectable left, TSelectable right)
        where TSelectable : ISelectableBase
            => left.Id == right.Id;
        public static bool Is<TSelectable>(this TSelectable primary, params TSelectable[] others)
        where TSelectable : ISelectableBase
            => others.Any(s => s.Id == primary.Id);
    }
}
