namespace Codespirals.Base;

/// <summary>
/// Extensions on <see cref="Guid"/>
/// </summary>
public static class GuidExtensions
{
    /// <summary>
    /// Convert a <see cref="Guid"/> to a shorter 22 character string
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string ToBase64(this Guid id)
        => Convert.ToBase64String(id.ToByteArray())[..22];

    /// <summary>
    /// Convert a <see cref="Guid"/> to a shorter 22 character string but remove all symbols that would be an issue in an URL
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string ToBase64UrlSafe(this Guid id)
    {
        var b64guid = id.ToBase64();
        // get a pseudo random number from the id to keep the replacements deterministic
        var i = new Random(id.GetHashCode()).Next(StringConstants.UpperCaseLetters.Length);
        foreach (var c in WebConstants.UrlReservedCharacters)
        {
            b64guid = b64guid.Replace(c, StringConstants.UpperCaseLetters[i]);
            i = (i + 7) % WebConstants.UrlReservedCharacters.Length;
        }
        return b64guid.ToString();
    }

}
