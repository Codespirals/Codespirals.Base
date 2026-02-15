using Codespirals.Base.Extensions;
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
    /// <param name="isSorted">Indicates whether <paramref name="items"/> is pre-sorted or not. If not this methods attempts a property-name sort based on <see cref="IFilterParameters.Sort"/></param>
    /// <returns></returns>
    public static IEnumerable<TItem> ApplyPagination<TItem, TPaginationParameters>(this IEnumerable<TItem> items, TPaginationParameters parameters, out int totalResults, int maxLimit = -1, bool isSorted = true)
        where TPaginationParameters : IFilterParameters
    {
        totalResults = 0;
        if (items is null || !items.Any())
            return [];
        totalResults = items.Count();
        if (!isSorted)
            items = items.OrderByProperty(parameters.Sort, parameters.Ascending);
        maxLimit = maxLimit > 0 ? maxLimit : short.MaxValue;
        var limit = Math.Clamp(parameters.Limit, 1, maxLimit);
        var maxPage = (int)Math.Ceiling((double)totalResults / limit);
        var page = Math.Clamp(parameters.Page, 0, maxPage);
        return items.Skip(page * limit).Take(limit);
    }
    /// <summary>
    /// Convert a set of filter parameters to a dictionary
    /// </summary>
    /// <typeparam name="TParameters"></typeparam>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ToDictionary<TParameters>(this TParameters parameters)
        where TParameters : IFilterParameters
    {
        Dictionary<string, string> dict = [];
        var props = typeof(TParameters).GetProperties();
        foreach (var prop in props)
        {
            var value = prop.GetValue(parameters);
            if (value is not null)
                dict.Add(prop.Name, value.ToString() ?? string.Empty);
        }
        return dict;
    }
}
