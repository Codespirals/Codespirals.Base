using System.Numerics;

namespace Codespirals.Base.Extensions
{
    public static class BinaryIntegerExtensions
    {
        public static bool CheckBitAtPosition<TNumber>(this TNumber number, int position)
            where TNumber : IBinaryInteger<TNumber>, IEquatable<TNumber>
            => (number & (TNumber.One << position)) != TNumber.Zero;
    }
}
