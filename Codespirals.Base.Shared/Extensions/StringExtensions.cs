namespace Codespirals.Base
{
    public static class StringExtensions
    {
        public static string GenerateRandomStringFromCharacters(this string allowedCharacters, int length, bool capitalizeOnlyFirstLetter = false)
        {
            var s = new string([.. Enumerable.Repeat(allowedCharacters, length).Select(s => s[Random.Shared.Next(s.Length)])]);
            if (capitalizeOnlyFirstLetter)
                return $"{s.First().ToString().ToUpper()}{s[1..].ToLower()}";
            else
                return s;
        }
    }
}
