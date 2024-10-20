using Codespirals.Base.Data;

namespace Codespirals.Base
{
    public static class Languages
    {
        public static Language GetLanguage(string isoCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(isoCode, nameof(isoCode));
            isoCode = isoCode[..2].ToLowerInvariant();
            using var db = new ResourceContext("resources");
            if (!db.Languages.Any())
                SeedData.SeedLanguages("resources");
            return db.Languages.FirstOrDefault(l => l.IsoCode == isoCode) ?? new Language();
        }
        public static List<Language> GetLanguages()
        {
            using var db = new ResourceContext("resources");
            if (!db.Languages.Any())
                SeedData.SeedLanguages("resources");
            return [.. db.Languages];
        }
    }
}
