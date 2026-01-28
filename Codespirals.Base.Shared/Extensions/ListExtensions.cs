namespace Codespirals.Base.Extensions;

/// <summary>
/// Extensions on <see cref="List{T}"/>
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Returns all elements of a list that are not null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> list) => list.Where(i => i is not null)!;

    /// <summary>
    /// Returns a list in random order
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static IEnumerable<TItem> Shuffle<TItem>(this IEnumerable<TItem> list)
    {
        var n = list.Count();
        var temp = list.ToList();
        while (n > 1)
        {
            n--;
            var k = Random.Shared.Next(n + 1);
            (temp[n], temp[k]) = (temp[k], temp[n]);
        }
        return temp;
    }

    /// <summary>
    /// Returns a list ordered by a property of the items in it
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="list"></param>
    /// <param name="propertyName"></param>
    /// <param name="ascending"></param>
    /// <returns></returns>
    public static IOrderedEnumerable<TItem> OrderByProperty<TItem>(this IEnumerable<TItem> list, string propertyName, bool ascending = true)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
            return ascending
                ? list.Order()
                : list.OrderDescending();
        var propertyInfo = typeof(TItem).GetProperty(propertyName);
        if (propertyInfo is null)
            return ascending
                ? list.Order()
                : list.OrderDescending();
        return ascending
            ? list.OrderBy(e => propertyInfo.GetValue(e, null))
            : list.OrderByDescending(e => propertyInfo.GetValue(e, null));
    }
}
