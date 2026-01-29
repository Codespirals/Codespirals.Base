using System.Numerics;

namespace Codespirals.Base.Extensions;

/// <summary>
/// Extensions on <see cref="IBinaryInteger{TSelf}"/>
/// </summary>
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
    {
        position &= number.SizeInBits();
        return (number & (TNumber.One << position)) != TNumber.Zero;
    }

    /// <summary>
    /// Checks the value (0/1) of a bit in a binary number at the given position or <see langword="null"/> if the position is out of range
    /// </summary>
    /// <typeparam name="TNumber"></typeparam>
    /// <param name="number"></param>
    /// <param name="position">The position counting from the right </param>
    /// <returns></returns>
    /// <remarks>For signed Binary Numbers, this discards the most significant bit.</remarks>
    public static bool? CheckBitAtPositionOverflowSafe<TNumber>(this TNumber number, int position)
        where TNumber : IBinaryInteger<TNumber>, IEquatable<TNumber>
    {
        if (position >= number.SizeInBits())
            return null;
        return (number & (TNumber.One << position)) != TNumber.Zero;
    }

    /// <summary>
    /// Calculate the size of a binary number in bits required to store it - excluding the potential most significant bit representing negative numbers.
    /// </summary>
    /// <typeparam name="TNumber"></typeparam>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int SizeInBits<TNumber>(this TNumber number)
        where TNumber : IBinaryInteger<TNumber>, IEquatable<TNumber>
    {
        var size = 0;
        // make sure number is not negative
        if (number < TNumber.Zero)
        {
            number -= TNumber.One;
            number = ~number;
        }
        while (number != TNumber.Zero)
        {
            size++;
            number >>= 1;
        }
        return size;
    }
}
