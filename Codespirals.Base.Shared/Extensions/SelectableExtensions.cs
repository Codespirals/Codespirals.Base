namespace Codespirals.Base;

public static class SelectableExtensions
{
    public static bool Is<TSelectable>(this TSelectable? primary, string? otherId)
    where TSelectable : ISelectableBase
        => primary is not null && otherId is not null && primary.Id == otherId;

    public static bool Is<TSelectable>(this TSelectable? primary, TSelectable? other)
    where TSelectable : ISelectableBase
        => primary.Is(other?.Id);

    public static bool IsAnyOf<TSelectable>(this TSelectable? primary, params string[]? othersIds)
    where TSelectable : ISelectableBase
        => othersIds is not null && othersIds.Any(s => primary.Is(s));

    public static bool IsAnyOf<TSelectable>(this TSelectable? primary, params TSelectable[]? others)
    where TSelectable : ISelectableBase
        => others is not null && others.Any(s => primary.Is(s.Id));
}
