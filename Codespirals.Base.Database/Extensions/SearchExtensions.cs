using Codespirals.Base;

namespace Codespirals.Base
{
    public static class SearchExtensions
    {
        public static TSearchResult Search<TItem, TSearch, TSearchResult>(this IEnumerable<TItem> list, string targetPropertyName, TSearch search, bool returnAll = false)
            where TSearch : ISearch
            where TSearchResult : ISearchResult<TSearch, TItem>, new()
        {
            try
            {
                var targetProperty = typeof(TItem).GetProperty(targetPropertyName) ?? throw new Exception();
                var results = list.Where(i => (targetProperty.GetValue(i)!.ToString() ?? "").Contains(search.Query, StringComparison.OrdinalIgnoreCase));
                if (returnAll)
                    return new TSearchResult { Results = results.ToList(), TotalResults = results.Count(), Search = search };
                return new TSearchResult { Results = results.Skip(search.Page * search.Limit).Take(search.Limit).ToList(), TotalResults = results.Count(), Search = search };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static TSearchResult SearchByName<TItem, TSearch, TSearchResult>(this IEnumerable<TItem> list, TSearch search, bool returnAll = false)
            where TItem : INameable
            where TSearch : ISearch
            where TSearchResult : ISearchResult<TSearch, TItem>, new()
            => list.Search<TItem, TSearch, TSearchResult>(nameof(INameable.Name), search, returnAll);

        public static TSearchResult SearchByDescription<TItem, TSearch, TSearchResult>(this IEnumerable<TItem> list, TSearch search, bool returnAll = false)
            where TItem : IDescribable
            where TSearch : ISearch
            where TSearchResult : ISearchResult<TSearch, TItem>, new()
            => list.Search<TItem, TSearch, TSearchResult>(nameof(IDescribable.Description), search, returnAll);
    }
}
