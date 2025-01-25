namespace Codespirals.Base
{
    public static class SelectableExtensions
    {
        public static bool Is<TSelectable>(this TSelectable? primary, string? otherId)
        where TSelectable : ISelectableBase
            => primary is not null && otherId is not null && primary.Id == otherId;

        public static bool Is<TSelectable>(this TSelectable? primary, TSelectable? other)
        where TSelectable : ISelectableBase
            => primary is not null && other is not null && primary.Is(other.Id);

        public static bool Is<TSelectable>(this TSelectable? primary, params TSelectable[]? others)
        where TSelectable : ISelectableBase
            => primary is not null && others is not null && others.Any(s => primary.Is(s.Id));
    }
}
