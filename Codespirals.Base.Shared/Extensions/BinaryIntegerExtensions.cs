using System.Numerics;

namespace Codespirals.Base;

public static class BinaryIntegerExtensions
{
    /// <summary>
    /// Checks the value (0/1) of a bit in a binary number at the given position.
    /// </summary>
    /// <typeparam name="TNumber"></typeparam>
    /// <param name="number"></param>
    /// <param name="position">The position counting from the right </param>
    /// <returns></returns>
    public static bool CheckBitAtPosition<TNumber>(this TNumber number, int position)
        where TNumber : IBinaryInteger<TNumber>, IEquatable<TNumber>
        => (number & (TNumber.One << position)) != TNumber.Zero;
}
