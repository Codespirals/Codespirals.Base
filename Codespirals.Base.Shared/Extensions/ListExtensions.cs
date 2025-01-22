namespace Codespirals.Base
{
    public static class ListExtensions
    {
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> list) => list.Where(i => i is not null)!;
    }
}
