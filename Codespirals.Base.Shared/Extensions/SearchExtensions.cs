namespace Codespirals.Base
{
    public static class SearchExtensions
    {
        public static IEnumerable<TItem> ApplySearchParameters<TItem, TParameters>(this IEnumerable<TItem> entities, TParameters search, int maxLimit, out int totalResults)
            where TParameters : IFilterParameters
        {
            totalResults = entities.Count();
            var limit = Math.Clamp(search.Limit, 1, maxLimit);
            var maxPage = entities.Count() / limit;
            var page = Math.Clamp(search.Page - 1, 0, maxPage);
            return entities.Skip(page * limit).Take(limit);
        }

    }
}
