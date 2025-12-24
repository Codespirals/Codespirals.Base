namespace Codespirals.Base.Extensions;

/// <summary>
/// Extensions on <see cref="string"/>
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// A small helper function to generate random text from a given input
    /// </summary>
    /// <param name="allowedCharacters"></param>
    /// <param name="length"></param>
    /// <param name="capitalizeOnlyFirstLetter"></param>
    /// <returns></returns>
    public static string GenerateRandomStringFromCurrentString(this string allowedCharacters, int length, bool capitalizeOnlyFirstLetter = false)
    {
        var s = new string([.. Enumerable.Repeat(allowedCharacters, length).Select(s => s[Random.Shared.Next(s.Length)])]);
        if (capitalizeOnlyFirstLetter)
            return $"{s.First().ToString().ToUpper()}{s[1..].ToLower()}";
        else
            return s;
    }
}
