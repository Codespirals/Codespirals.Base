using Codespirals.Base.Extensions;

namespace Codespirals.Base.Helpers;
/// <summary>
/// A small helper for <see cref="string"/>s
/// </summary>
public static class StringHelper
{
    /// <summary>
    /// Generate a string from common letters
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GenerateRandomString(int length)
        => StringConstants.Letters.GenerateRandomStringFromCurrentString(length);

    /// <summary>
    /// Generate a string from common letters and numbers
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GenerateRandomAlphanumericString(int length)
        => StringConstants.Alphanumeric.GenerateRandomStringFromCurrentString(length);

    /// <summary>
    /// Generates a string that should sort of look like a name
    /// </summary>
    /// <returns></returns>
    public static string GenerateName()
        => Random.Shared.NextDouble() > 0.7
        ? $"{StringConstants.Consonants.GenerateRandomStringFromCurrentString(1, true)}{StringConstants.Vowels.GenerateRandomStringFromCurrentString(1)}{StringConstants.LowerCaseLetters.GenerateRandomStringFromCurrentString(Random.Shared.Next(1, 12))}"
        : $"{StringConstants.Vowels.GenerateRandomStringFromCurrentString(1, true)}{StringConstants.Consonants.GenerateRandomStringFromCurrentString(1)}{StringConstants.LowerCaseLetters.GenerateRandomStringFromCurrentString(Random.Shared.Next(1, 12))}";

}
