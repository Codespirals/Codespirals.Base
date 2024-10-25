namespace Codespirals.Base
{
    public interface ICountry : ICountryBase, IIdentifiable
    {
        string? Flag { get; }
    }
}