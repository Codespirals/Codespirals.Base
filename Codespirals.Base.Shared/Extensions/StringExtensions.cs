namespace Codespirals.Base
{
    public static class StringExtensions
    {
        private static readonly Random random = new();
        public static string GenerateRandomStringFromCharacters(this string allowedCharacters, int length, bool capitalizeOnlyFirstLetter = false)
        {
            var s = new string(Enumerable.Repeat(allowedCharacters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            if (capitalizeOnlyFirstLetter)
                return $"{s.First().ToString().ToUpper()}{s[1..].ToLower()}";
            else
                return s;
        }
    }
}
