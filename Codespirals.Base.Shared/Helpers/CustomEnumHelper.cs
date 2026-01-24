namespace Codespirals.Base.Helpers;

/// <summary>
/// A small helper for custom enums
/// </summary>
public static class CustomEnumHelper
{
    /// <summary>
    /// Get the allowable values from a <see cref="IIsEnum{TSelf}"/> object
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    public static List<TEnum> GetAllowableValues<TEnum>()
        where TEnum : IIsEnum<TEnum>, new()
    {
        try
        {
            var results = new List<TEnum>();
            var properties = typeof(TEnum).GetProperties();
            var instance = new TEnum();
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(instance);
                if (propValue is null or not ISelectableBase)
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
    /// <param name="id"></param>
    /// <returns>The value or the <see cref="IDefaultable{TSelf}.Default"/>, if it doesn't exist</returns>
    public static TEnum GetValueFromId<TEnum>(string? id)
        where TEnum : IIsEnum<TEnum>, new()
        => GetAllowableValues<TEnum>().FirstOrDefault(r => r.Id == id) ?? TEnum.Default();

    /// <summary>
    /// Check if a selectable item is part of a custom enum
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TSelectable"></typeparam>
    /// <param name="item"></param>
    /// <returns></returns>
    public static bool IsAcceptableValue<TEnum, TSelectable>(this TSelectable item)
        where TEnum : IIsEnum<TEnum>, new()
        where TSelectable : ISelectableBase, new()
        => item.IsAnyOf(GetAllowableValues<TEnum>().Select(v => v.Id).ToArray());
}
