namespace Codespirals.Base.Helpers;

/// <summary>
/// 
/// </summary>
public static class MappingHelper
{
    /// <summary>
    /// A primitive Auto Mapper
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="TItem2"></typeparam>
    /// <param name="item"></param>
    /// <param name="values"></param>
    /// <remarks>Only for identically named properties. Meant for small scale use. For real production work get actual AutoMapper from NuGet.</remarks>
    public static void MapProperties<TItem, TItem2>(TItem item, TItem2 values)
    {
        var propertiesToFill = typeof(TItem).GetProperties().Where(x => x.CanWrite);
        foreach (var property in propertiesToFill)
        {
            var match = typeof(TItem2).GetProperty(property.Name);
            if (match is null)
                continue;
            var value = match.GetValue(values);
            if (value is null)
                continue;
            match.SetValue(item, value);
        }
    }
}
