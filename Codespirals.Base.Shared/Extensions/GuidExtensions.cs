namespace Codespirals.Base.Extensions;

/// <summary>
/// Extensions on <see cref="Guid"/>
/// </summary>
public static class GuidExtensions
{
    /// <summary>
    /// Convert a <see cref="Guid"/> into to a shorter 22 character string in Base64
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string ToBase64(this Guid id)
        => Convert.ToBase64String(id.ToByteArray());

    /// <summary>
    /// Convert a <see cref="Guid"/> into a shorter Base64 string and then makes that string url safe
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <remarks>This action is deterministic, but  not reversible</remarks>
    public static string ToUrlSafeBase64(this Guid id)
        => id.ToBase64().Trim('=').MakeUrlSafe();
}
