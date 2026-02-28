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
        var hashCode = s.GetHashCode();
        foreach (var c in WebConstants.UrlReservedCharacters)
        {
            if (!s.Contains(c))
                continue;
            // get a seeded random number from the current string to keep the replacements deterministic
            var i = new Random(hashCode).Next(StringConstants.Alphanumeric.Length);
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
            Convert.ToByte(c >> 8),
            Convert.ToByte(c)
        ];
    }
    /// <summary>
    /// Checks if given string is equal to any of the strings in parameters
    /// </summary>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <remarks>Ignores case</remarks>
    public static bool IsAnyOf(this string? value, params string[] values)
    {
        if (value is null) { return false; }
        foreach (var item in values)
        {
            if (string.Equals(value, item, StringComparison.InvariantCultureIgnoreCase))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Removes all whitespace from a string
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string? RemoveWhitespace(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;
        return CompiledRegex.DetectWhitespace().Replace(value, string.Empty);
    }
}
