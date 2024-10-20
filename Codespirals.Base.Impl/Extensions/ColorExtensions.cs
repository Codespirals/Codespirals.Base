namespace Codespirals.Base
{
    public static class ColorExtensions
    {
        public static string ToHex(this IColor color)
            => $"{color.R:X2}{color.G:X2}{color.B:X2}";
        public static string ToHexA(this IColor color)
            => $"{color.R:X2}{color.G:X2}{color.B:X2}{color.A:X2}";
        public static (byte R, byte G, byte B) ToRGB(this IColor color)
            => (color.R, color.G, color.B);
        public static (byte R, byte G, byte B, float A) ToRGBA(this IColor color)
            => (color.R, color.G, color.B, float.Round(color.A / 255, 1));
    }
}
