namespace Codespirals.Base.Helpers;

public static class MappingHelper
{
    public static void MapProperties<TItem, TValues>(TItem item, TValues values)
    {
        var propertiesToFill = typeof(TItem).GetProperties().Where(x => x.CanWrite);
        foreach (var property in propertiesToFill)
        {
            var match = typeof(TValues).GetProperty(property.Name);
            if (match is null)
                continue;
            var value = match.GetValue(values);
            if (value is null)
                continue;
            match.SetValue(item, value);
        }
    }
}
