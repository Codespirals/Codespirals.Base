namespace Codespirals.Base.Exceptions
{
    public class CurrencyNotFoundException(string isoCode) : Exception($"Currency with ISO code {isoCode} could not be found")
    {
    }
}
