namespace Codespirals.Base.Exceptions
{
    public class CountryNotFoundException(string isoCode) : Exception($"Country with ISO code {isoCode} could not be found")
    {
    }
}
