using Codespirals.Base;

namespace Codespirals.Common
{
    public class FilterParameters : IFilterParameters
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public string Sort { get; set; } = "";

        public bool Ascending { get; set; }
    }
}
