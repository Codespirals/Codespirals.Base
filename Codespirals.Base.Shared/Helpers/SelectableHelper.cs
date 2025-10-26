namespace Codespirals.Base;

public static class SelectableHelper
{
    public static List<TEnum> GetAllowableValues<TEnum>()
        where TEnum : IIsEnum<TEnum>, new()
    {
        try
        {
            var list = new List<TEnum>();
            var allowableValues = new TEnum();
            var properties = typeof(TEnum).GetProperties();
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(allowableValues);
                if (propValue is null)
                    continue;
                if (propValue is TEnum cast)
                {
                    list.Add(cast);
                }
            }
            return [.. list];
        }
        catch (Exception)
        {
            return [];
        }
    }
    public static TEnum GetSelectableFromId<TEnum>(string? id)
        where TEnum : IIsEnum<TEnum>, new()
    {
        if (string.IsNullOrWhiteSpace(id))
            return TEnum.Default();
        return GetAllowableValues<TEnum>().FirstOrDefault(r => r.Id == id) ?? TEnum.Default();
    }
    public static bool IsAnyOf<TEnum>(TEnum item, params string[] args)
        where TEnum : IIsEnum<TEnum>, new()
        => args.Any(v => item.Id == v);
    public static bool IsAnyOf<TEnum>(TEnum item, params TEnum[] args)
        where TEnum : IIsEnum<TEnum>, new()
        => args.Any(v => item.Id == v.Id);
}
