namespace Codespirals.Base.Extensions
{
    public static class StringExtensions
    {
        private static readonly Random random = new();
        public static string GenerateRandomStringFromCharacters(this string allowedCharacters, int length)
        {
            return new string(Enumerable.Repeat(allowedCharacters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
