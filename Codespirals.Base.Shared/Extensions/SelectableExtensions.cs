using Codespirals.Base.Extensions;

namespace Codespirals.Base;

/// <summary>
/// Extensions on <see cref="ISelectableBase"/>
/// </summary>
public static class SelectableExtensions
{
    /// <summary>
    /// Compare two selectable items and check if they're the same
    /// </summary>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="primary"></param>
    /// <param name="otherId"></param>
    /// <returns></returns>
    public static bool Is<TSelectable>(this TSelectable primary, string? otherId)
    where TSelectable : ISelectableBase
        => otherId is not null && primary.Id == otherId;

    /// <summary>
    /// Compare two selectable items and check if they're the same
    /// </summary>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="primary"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static bool Is<TSelectable>(this TSelectable primary, TSelectable? other)
    where TSelectable : ISelectableBase
        => primary.Is(other?.Id);

    /// <summary>
    /// Check if the current selectable item is in a list of selectable items
    /// </summary>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="primary"></param>
    /// <param name="othersIds"></param>
    /// <returns></returns>
    public static bool IsAnyOf<TSelectable>(this TSelectable primary, params string[] othersIds)
    where TSelectable : ISelectableBase
        => primary.Id.IsAnyOf(othersIds);

    /// <summary>
    /// Check if the current selectable item is in a list of selectable items
    /// </summary>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="primary"></param>
    /// <param name="others"></param>
    /// <returns></returns>
    public static bool IsAnyOf<TSelectable>(this TSelectable primary, params TSelectable[] others)
    where TSelectable : ISelectableBase
        => primary.Id.IsAnyOf([.. others.Select(s => s.Id)]);
}
