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
    /// <remarks>NOT url safe. This action is reversible with <see cref="Helpers.GuidHelper.FromBase64(string)"/></remarks>
    public static string ToBase64(this Guid id)
        => Convert.ToBase64String(id.ToByteArray());

    /// <summary>
    /// Convert a <see cref="Guid"/> into a shorter Base64 string and then makes that string url safe
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <remarks>This action is deterministic, but  not reversible</remarks>
    public static string ToBase64UrlSafe(this Guid id)
        => id.ToBase64().Trim('=').MakeUrlSafe();

    /// <summary>
    /// Convert a <see cref="Guid"/> into a shorter, url safe string starting with a max 4 character prefix that marks it as obscure
    /// </summary>
    /// <param name="id"></param>
    /// <param name="marker">Max 4 character prefix to identify this as obscured.</param>
    /// <returns></returns>
    public static string ToObscureId(this Guid id, string marker)
        => $"{marker[..4].MakeUrlSafe}{id.ToBase64().Trim('=').MakeUrlSafe()}";
}
