namespace Codespirals.Base
{
    public static class AdvancedSearchExtensions
    {
        public static TSearchResult Search<TItem, TSearch, TSearchResult>(IEnumerable<TItem> list, string idPropertyName, string targetPropertyName, TSearch search, bool returnAll = false, char excludeSymbol = '-', char andSymbol = '+', char[]? seperatorsSymbols = null)
            where TSearch : ISearch
            where TSearchResult : ISearchResult<TSearch, TItem>, new()
        {
            try
            {
                var idProperty = typeof(TItem).GetProperty(idPropertyName) ?? throw new SearchPropertyReflectionException($"Could not find property {nameof(idPropertyName)}:{idPropertyName} on {typeof(TItem)}");
                var targetProperty = typeof(TItem).GetProperty(targetPropertyName) ?? throw new SearchPropertyReflectionException($"Could not find property {nameof(targetPropertyName)}:{targetPropertyName} on {typeof(TItem)}");

                var items = list.Select(i => (Id: (idProperty.GetValue(i) ?? "").ToString()!, Target: (targetProperty.GetValue(i) ?? "").ToString()!)) ?? throw new InvalidCastException($"Failed to cast from list item to a (string, string) touple.");
                var filteredIds = FilterAdvanced(items, excludeSymbol, andSymbol, search.SplitQuery(seperatorsSymbols));

                var results = filteredIds.Select(f => list.First(i => (idProperty.GetValue(i) ?? "").ToString() == f));
                if (returnAll)
                    return new TSearchResult { Results = results.ToList(), TotalResults = results.Count(), Search = search };
                return new TSearchResult { Results = results.Skip(search.Page * search.Limit).Take(search.Limit).ToList(), TotalResults = results.Count(), Search = search };
            }
            catch (SearchPropertyReflectionException e)
            {
                throw new SearchPropertyReflectionException(e.Message);
            }
            catch (InvalidCastException e)
            {
                throw new InvalidCastException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static TSearchResult SearchByName<TItem, TSearch, TSearchResult>(this IEnumerable<TItem> list, TSearch search, bool returnAll = false, char excludeSymbol = '-', char andSymbol = '+', char[]? seperatorsSymbols = null)
            where TItem : IIdentifiable, INameable
            where TSearch : ISearch
            where TSearchResult : ISearchResult<TSearch, TItem>, new()
        {
            var filtered = FilterAdvanced(list.Select(i => (i.Id, i.Name)), excludeSymbol, andSymbol, searchTerms: search.SplitQuery(seperatorsSymbols));
            var results = filtered.Select(f => list.First(i => i.Id == f));
            if (returnAll)
                return new TSearchResult { Results = results.ToList(), TotalResults = results.Count(), Search = search };
            return new TSearchResult { Results = results.Skip(search.Page * search.Limit).Take(search.Limit).ToList(), TotalResults = results.Count(), Search = search };
        }

        private static string[] SplitQuery(this ISearch search, char[]? separators = null)
        {
            separators ??= [',', ';', ' '];
            return search.Query.Split(separators, StringSplitOptions.TrimEntries);
        }

        private static IEnumerable<string> FilterAdvanced(IEnumerable<(string Id, string Target)> items, char excludeSymbol = '-', char andSymbol = '+', params string[] searchTerms)
        {
            var filteredIds = items;
            var excludeTerms = searchTerms.Where(t => t.StartsWith(excludeSymbol));
            filteredIds = NotFilter(filteredIds, (string[])excludeTerms);
            var andTerms = searchTerms.Where(t => t.StartsWith(andSymbol));
            filteredIds = AndFilter(filteredIds, (string[])andTerms);
            var orTerms = searchTerms.Except(excludeTerms).Except(andTerms);
            filteredIds = OrFilter(filteredIds, (string[])orTerms);
            return filteredIds.Select(i => i.Id);
        }

        internal static IEnumerable<(string Id, string Target)> OrFilter(IEnumerable<(string Id, string Target)> items, params string[] searchTerms)
        {
            if (searchTerms.Length < 1)
                return items;
            var res = new List<(string Id, string Target)>();
            foreach (var term in searchTerms)
            {
                var temp = items.Where(i => i.Target.Contains(term));
                res.AddRange(temp);
            }
            // order results by how many search terms matched the target
            return res.GroupBy(i => i.Id).OrderByDescending(g => g.Count()).Select(g => g.First());
        }
        internal static IEnumerable<(string Id, string Target)> NotFilter(IEnumerable<(string Id, string Target)> items, params string[] searchTerms)
        {
            if (searchTerms.Length < 1)
                return items;
            var res = new List<(string Id, string Target)>();
            foreach (var term in searchTerms)
            {
                var temp = items.Where(i => !i.Target.Contains(term.Trim('-')));
                res.AddRange(temp);
            }
            return res.Distinct();
        }
        internal static IEnumerable<(string Id, string Target)> AndFilter(IEnumerable<(string Id, string Target)> items, params string[] searchTerms)
        {
            if (searchTerms.Length < 1)
                return items;
            var temp = new List<(string Id, string Target)>();
            foreach (var term in searchTerms)
            {
                var matches = items.Where(i => i.Target.Contains(term.Trim('+')));
                temp.AddRange(matches);
            }
            var res = new List<(string Id, string Target)>();
            foreach (var item in temp.GroupBy(i => i).Where(g => g.Count() == searchTerms.Length).First())
            {
                res.Add(item);
            }
            return res;
        }
    }
}
