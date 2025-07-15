namespace Codespirals.Base
{
    public class SearchParameters : ISearchParameters
    {
        public string Query { get; set; } = "";

        public int Page { get; set; }

        public int Limit { get; set; }

        public string Sort { get; set; } = "";

        public bool Ascending { get; set; }
    }
}
