namespace Codespirals.Base.Exceptions
{
    internal class LanguageNotFoundException(string isoCode) : Exception($"Language with ISO code {isoCode} could not be found")
    {
    }
}
