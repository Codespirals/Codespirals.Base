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
        => primary.Id == other?.Id;

    /// <summary>
    /// Check if the current selectable item is in a list of selectable items
    /// </summary>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="primary"></param>
    /// <param name="othersIds"></param>
    /// <returns></returns>
    public static bool IsAnyOf<TSelectable>(this TSelectable primary, params string[] othersIds)
    where TSelectable : ISelectableBase
        => othersIds is not null && othersIds.Any(s => primary.Is(s));

    /// <summary>
    /// Check if the current selectable item is in a list of selectable items
    /// </summary>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="primary"></param>
    /// <param name="others"></param>
    /// <returns></returns>
    public static bool IsAnyOf<TSelectable>(this TSelectable primary, params TSelectable[] others)
    where TSelectable : ISelectableBase
        => others is not null && others.Any(s => primary.Is(s));

    /// <summary>
    /// Get the allowable values from a <see cref="IIsEnum{TSelf}"/> object
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="customEnum"></param>
    /// <returns></returns>
    public static List<TEnum> GetAllowableValues<TEnum>(this TEnum customEnum)
        where TEnum : IIsEnum<TEnum>, new()
    {
        try
        {
            var results = new List<TEnum>();
            var properties = customEnum.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (prop is not ISelectableBase)
                    continue;
                var propValue = prop.GetValue(customEnum);
                if (propValue is null)
                    continue;
                if (propValue is TEnum cast)
                {
                    results.Add(cast);
                }
            }
            return [.. results];
        }
        catch (Exception)
        {
            return [];
        }
    }

    /// <summary>
    /// Get a <see cref="ISelectableBase"/> value from an <see cref="IIsEnum{TSelf}"/>
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="customEnum"></param>
    /// <param name="id"></param>
    /// <returns>The value or the <see cref="IDefaultable{TSelf}.Default"/>, if it doesn't exist</returns>
    public static TEnum GetValueFromId<TEnum>(this TEnum customEnum, string? id)
        where TEnum : IIsEnum<TEnum>, new()
        => customEnum.GetAllowableValues().FirstOrDefault(r => r.Id == id) ?? TEnum.Default();

    /// <summary>
    /// Check if a selectable item is part of a custom enum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="customEnum"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public static bool IsAcceptableValue<TEnum, TSelectable>(this TSelectable item, TEnum customEnum)
        where TEnum : IIsEnum<TEnum>, new()
        where TSelectable : ISelectableBase, new()
        => customEnum.GetAllowableValues().Any(v => v.Id == item.Id);
}
