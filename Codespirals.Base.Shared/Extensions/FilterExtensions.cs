using Codespirals.Base.Filtering;

namespace Codespirals.Base;

/// <summary>
/// Extensions on <see cref="FilterParameters"/>
/// </summary>
public static class FilterExtensions
{
    /// <summary>
    /// Apply a set of filter parameters to a list and return the resulting items
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <typeparam name="TPaginationParameters"></typeparam>
    /// <param name="items">The initial list - this should be already pre-filtered and ordered</param>
    /// <param name="parameters">The pagination parameters, implementing <see cref="IFilterParameters"/></param>
    /// <param name="maxLimit">Limit how many items can be returned per page to prevent enduser shenanigans</param>
    /// <param name="totalResults">Return a count of the list before filtering (for pagination)</param>
    /// <returns></returns>
    public static IEnumerable<TItem> ApplyPagination<TItem, TPaginationParameters>(this IEnumerable<TItem> items, TPaginationParameters parameters, short maxLimit, out int totalResults)
        where TPaginationParameters : IFilterParameters
    {
        items ??= [];
        totalResults = items.Count();
        var limit = maxLimit > 1 ? Math.Clamp(parameters.Limit, 1, maxLimit) : short.MaxValue;
        var maxPage = items.Count() / limit;
        var page = Math.Clamp(parameters.Page, 0, maxPage);
        return items.Skip(page * limit).Take(limit);
    }
}
