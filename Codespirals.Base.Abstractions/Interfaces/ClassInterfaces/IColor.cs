namespace Codespirals.Base
{
    public interface IColor
    {
        public string Hex { get; }
        public string HexA { get; }
        public (byte R, byte G, byte B) RGB { get; }
        public (byte R, byte G, byte B, float A) RGBA { get; }
    }
}
