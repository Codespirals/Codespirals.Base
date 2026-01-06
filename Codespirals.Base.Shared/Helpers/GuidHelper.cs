namespace Codespirals.Base.Helpers;
/// <summary>
/// A small helper class to work with <see cref="Guid"/>s
/// </summary>
public static class GuidHelper
{
    /// <summary>
    /// Convert a Base64 string into a <see cref="Guid"/>
    /// </summary>
    /// <param name="base64String">The base64 encoded string to create the GUID from</param>
    /// <returns></returns>
    public static Guid FromBase64(string base64String) => new(Convert.FromBase64String(base64String));
}
