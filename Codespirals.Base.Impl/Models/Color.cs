namespace Codespirals.Base.Models
{
    public record Color : IColor
    {
        private byte _r = 0;
        private byte _g = 0;
        private byte _b = 0;
        private byte _a = byte.MaxValue;
        public string Hex => $"{_r:X2}{_g:X2}{_b:X2}";
        public string HexA => $"{_r:X2}{_g:X2}{_b:X2}{_a:X2}";
        public (byte R, byte G, byte B) RGB => (_r, _g, _b);
        public (byte R, byte G, byte B, float A) RGBA => (_r, _g, _b, float.Round(_a / 255, 1));

        public Color(int r, int g, int b) => SetColorByRgb(r, g, b, byte.MaxValue);
        public Color(int r, int g, int b, float a) => SetColorByRgb(r, g, b, a);
        public Color(string hex) => SetColorByHex(hex);

        public string ToString(bool useAlpha = false)
            => $"#{(useAlpha ? HexA : Hex)}";
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

            _r = byte.Parse(hex[..i]);
            _g = byte.Parse(hex.Substring(1 * i, i));
            _b = byte.Parse(hex.Substring(2 * i, i));

            if (hex.Length % 4 == 0)
                _a = byte.Parse(hex.Substring(3 * i, i));

            if (hex.Length > 5)
            {
                _r = (byte)(_r << 1);
                _g = (byte)(_g << 1);
                _b = (byte)(_b << 1);
                _a = (byte)(_a << 1);
            }
        }
        private void SetColorByRgb(int r, int g, int b, float a = 1f)
            => SetColorByRgb(r, g, b, byte.MaxValue * Math.Clamp(a, 0.0f, 1.0f));
        private void SetColorByRgb(int r, int g, int b, int a = byte.MaxValue)
        {
            _r = (byte)Math.Clamp(r, byte.MinValue, byte.MaxValue);
            _g = (byte)Math.Clamp(g, byte.MinValue, byte.MaxValue);
            _b = (byte)Math.Clamp(b, byte.MinValue, byte.MaxValue);
            _a = (byte)Math.Clamp(a, byte.MinValue, byte.MaxValue);
        }

    }
}
