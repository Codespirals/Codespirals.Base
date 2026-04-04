using System.Numerics;

namespace Codespirals.Base.Extensions;

/// <summary>
/// Basic extensions for number types
/// </summary>
public static class NumberExtensions
{
    /// <summary>
    /// A quick percentage calculation method
    /// </summary>
    /// <typeparam name="TNumber"></typeparam>
    /// <param name="number"></param>
    /// <param name="total"></param>
    /// <returns></returns>
    public static float IsPercentOf<TNumber>(this TNumber number, TNumber total)
        where TNumber : INumber<TNumber>, IConvertible
        => (number / total).ToSingle(null) * 100f;
}
