using Codespirals.Base.Filtering;

namespace Codespirals.Base;

public static class FilterExtensions
{
    public static IEnumerable<TItem> ApplyFilterParameters<TItem, TFilter>(this IEnumerable<TItem> entities, TFilter filter, short maxLimit, out int totalResults)
        where TFilter : IFilterParameters
    {
        entities ??= [];
        totalResults = entities.Count();
        var limit = maxLimit > 1 ? Math.Clamp(filter.Limit, 1, maxLimit) : short.MaxValue;
        var maxPage = entities.Count() / limit;
        var page = Math.Clamp(filter.Page - 1, 0, maxPage);
        return entities.Skip(page * limit).Take(limit);
    }
}
