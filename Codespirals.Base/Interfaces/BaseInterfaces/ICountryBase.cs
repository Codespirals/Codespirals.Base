using Codespirals.Base.Interfaces.EnforcementInterfaces;

namespace Codespirals.Base
{
    public interface ICountryBase : INameable, IHasIsoCode
    {
        public string? Flag { get; set; }
    }
}
