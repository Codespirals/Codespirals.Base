namespace Codespirals.Base.Extensions;

/// <summary>
/// Extensions on <see cref="Guid"/>
/// </summary>
public static class GuidExtensions
{
    /// <summary>
    /// Convert a <see cref="Guid"/> that is in hexadecimal to a shorter 22 character string in Base64
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string ToBase64(this Guid id)
        => Convert.ToBase64String(id.ToByteArray());
}
