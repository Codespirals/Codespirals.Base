using Codespirals.Base.Models;

namespace Codespirals.Resources.Db
{
    public class ResourceData
    {
        public List<Currency> Currencies { get; set; } = new List<Currency>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<Language> Languages { get; set; } = new List<Language>();
    }
}
