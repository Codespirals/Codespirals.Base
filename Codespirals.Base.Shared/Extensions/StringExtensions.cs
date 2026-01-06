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
    /// <summary>
    /// Makes a string URL safe by replacing all risky characters with a deterministically random alphanumeric character
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string MakeUrlSafe(this string s)
    {
        foreach (var c in WebConstants.UrlReservedCharacters)
        {
            // get a seeded random number from the current string to keep the replacements deterministic
            var i = new Random(s.GetHashCode()).Next(StringConstants.Alphanumeric.Length);
            s = s.Replace(c, StringConstants.Alphanumeric[i]);
        }
        return s;
    }
    /// <summary>
    /// Turns a string into a byte array.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static byte[] ToByteArray(this string s)
        => [.. s.SelectMany(c => c.ToBytes())];

    /// <summary>
    /// Returns a <see langword="char"/> split into 2 bytes
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static byte[] ToBytes(this char c)
    {
        return
        [
            Convert.ToByte(c),
            Convert.ToByte(c >> 8),
        ];
    }
}
