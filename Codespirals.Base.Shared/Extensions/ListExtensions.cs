namespace Codespirals.Base
{
    public static class ListExtensions
    {
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> list) => list.Where(i => i is not null)!;

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Shared.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }
}
