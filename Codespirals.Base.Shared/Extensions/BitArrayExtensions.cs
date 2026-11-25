using System.Collections;

namespace Codespirals.Base.Extensions;

/// <summary>
/// Extensions for <see cref="BitArray"/>
/// </summary>
public static class BitArrayExtensions
{
    /// <summary>
    /// Gets the values from a <see cref="BitArray"/> as an array of <see cref="bool"/>s
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static bool[] GetValues(this BitArray array)
    {
        var res = new bool[array.Length];
        var i = 0;
        foreach (var item in array)
        {
            res[i] = (bool)item;
            i++;
        }
        return res;
    }
    /// <summary>
    /// Combine two <see cref="BitArray"/>s
    /// </summary>
    /// <param name="current"></param>
    /// <param name="other"></param>
    /// <returns>A new <see cref="BitArray"/> with <paramref name="other"/> attached to the end of the <paramref name="current"/> <see cref="BitArray"/></returns>
    public static BitArray Concat(this BitArray current, BitArray other)
    {
        var combined = new bool[current.Length + other.Length];

        current.CopyTo(combined, 0);
        other.CopyTo(combined, current.Length);

        return new BitArray(combined);
    }
    /// <summary>
    /// Add a bool to a <see cref="BitArray"/>
    /// </summary>
    /// <param name="current"></param>
    /// <param name="item"></param>
    public static void Add(this BitArray current, bool item)
    {
        var newLength = current.Count + 1;
        _ = current.Pad(newLength);
        current.Set(newLength, item);
    }
    /// <summary>
    /// Add a <see cref="BitArray"/> to another
    /// </summary>
    /// <param name="current"></param>
    /// <param name="other"></param>
    public static void Add(this BitArray current, BitArray other)
    {
        var newLength = current.Count + other.Count;
        _ = current.Pad(newLength, false);
        _ = other.Pad(newLength);
        _ = current.Or(other);
    }
    /// <summary>
    /// Pads the current <see cref="BitArray"/> with <see langword="false"/> (0) bits
    /// </summary>
    /// <param name="current"></param>
    /// <param name="length">The total length of the <see cref="BitArray"/> after the operation</param>
    /// <param name="padLeft">Add <see langword="false"/> (0) to the left or the right</param>
    /// <returns>The current <see cref="BitArray"/> padded with <see langword="false"/> (0) to the desired <paramref name="length"/></returns>
    public static BitArray Pad(this BitArray current, int length, bool padLeft = true)
    {
        if (current.Length >= length)
            return current;

        if (padLeft)
        {
            var dif = length - current.Length;
            current.Length = length;
            _ = current.RightShift(dif);
        }
        else
            current.Length = length;

        return current;
    }
    /// <summary>
    /// Simply a method to set <see cref="BitArray.Length"/> to make it easier to use with Select
    /// </summary>
    /// <param name="current"></param>
    /// <param name="length"></param>
    /// <param name="cutLeft"></param>
    /// <returns>The current <see cref="BitArray"/>, cut to length</returns>
    public static BitArray CutToLength(this BitArray current, int length, bool cutLeft = true)
    {
        if (current.Length < length)
            return current;

        if (cutLeft)
        {
            var dif = current.Length - length;
            _ = current.LeftShift(dif);
            current.Length = length;
        }
        else
            current.Length = length;
        return current;
    }
}
