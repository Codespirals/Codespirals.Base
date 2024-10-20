namespace Codespirals.Base
{
    public record Color : IColor, IIdentifiable
    {
        public string Id => ToString(true);
        public byte R { get; private set; } = byte.MinValue;
        public byte G { get; private set; } = byte.MinValue;
        public byte B { get; private set; } = byte.MinValue;
        public byte A { get; private set; } = byte.MaxValue;

        public Color(int r, int g, int b) => SetColorByRgb(r, g, b, byte.MaxValue);
        public Color(int r, int g, int b, float a) => SetColorByRgb(r, g, b, a);
        public Color(string hex) => SetColorByHex(hex);

        public string ToString(bool useAlpha = false)
            => $"#{(useAlpha ? this.ToHexA() : this.ToHex())}";
        public override string ToString()
            => ToString(false);

        public static bool IsValidColorHex(string hex)
            => RegexExtensions.IsHexColorValue().IsMatch(hex);

        private void SetColorByHex(string hex)
        {
            if (!IsValidColorHex(hex))
            {
                return;
            }
            hex = hex.TrimStart('#');
            var i = 2;
            if (hex.Length <= 4)
                i = 1;

            R = byte.Parse(hex[..i]);
            G = byte.Parse(hex.Substring(1 * i, i));
            B = byte.Parse(hex.Substring(2 * i, i));

            if (hex.Length % 4 == 0)
                A = byte.Parse(hex.Substring(3 * i, i));

            if (hex.Length > 5)
            {
                R = (byte)(R << 1);
                G = (byte)(G << 1);
                B = (byte)(B << 1);
                A = (byte)(A << 1);
            }
        }
        private static void SetColorByRgb(int r, int g, int b, float a = 1f)
            => SetColorByRgb(r, g, b, byte.MaxValue * Math.Clamp(a, 0.0f, 1.0f));
        private void SetColorByRgb(int r, int g, int b, int a = byte.MaxValue)
        {
            R = (byte)Math.Clamp(r, byte.MinValue, byte.MaxValue);
            G = (byte)Math.Clamp(g, byte.MinValue, byte.MaxValue);
            B = (byte)Math.Clamp(b, byte.MinValue, byte.MaxValue);
            A = (byte)Math.Clamp(a, byte.MinValue, byte.MaxValue);
        }

    }
}
