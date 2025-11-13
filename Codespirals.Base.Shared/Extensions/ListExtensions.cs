namespace Codespirals.Base;

public static class ListExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> list) => list.Where(i => i is not null)!;

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
    public static IOrderedEnumerable<TItem> OrderByProperty<TListIn, TItem>(this TListIn list, string propertyName, bool ascending = true)
        where TListIn : IEnumerable<TItem>
    {
        propertyName ??= "";
        var propertyInfo = typeof(TItem).GetProperty(propertyName);
        if (string.IsNullOrWhiteSpace(propertyName) || propertyInfo == null)
            return ascending
                ? list.Order()
                : list.OrderDescending();
        return ascending
            ? list.OrderBy(e => propertyInfo.GetValue(e, null))
            : list.OrderByDescending(e => propertyInfo.GetValue(e, null));
    }
}
