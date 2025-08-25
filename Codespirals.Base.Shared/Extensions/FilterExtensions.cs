namespace Codespirals.Base
{
    public static class FilterExtensions
    {
        public static IEnumerable<TItem> ApplyFilterParameters<TItem, TParameters>(this IEnumerable<TItem> entities, TParameters search, short maxLimit, out int totalResults)
            where TParameters : IFilterParameters
        {
            entities ??= [];
            totalResults = entities.Count();
            var limit = maxLimit > 1 ? Math.Clamp(search.Limit, 1, maxLimit) : short.MaxValue;
            var maxPage = entities.Count() / limit;
            var page = Math.Clamp(search.Page - 1, 0, maxPage);
            return entities.Skip(page * limit).Take(limit);
        }
    }
}
