namespace Codespirals.Base.Resources.Statics
{
    public static class Colors
    {
        public static bool IsValidColorHex(string hex)
            => RegexExtensions.IsHexColorValue().IsMatch(hex);
        public static List<Color> GetRainbow(bool includeViolet = true)
        {
            var colors = new List<Color>() { new("E50000"), new("FF8D00"), new("FFEE00"), new("028121"), new("004CFF"), new("760088") };
            if (includeViolet) { colors.Add(new("9400D3")); }
            return colors;
        }
        public static Color GetRandom(bool includeAlpha)
        {
            var r = new Random();
            if (includeAlpha)
                return new Color(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            return new Color(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }
        public static List<Color> GetFade(this Color color, Color otherColor, int numberOfColors)
        {
            var percentageStep = Math.Clamp(100 / numberOfColors, 1, 100);
            var colors = new List<Color>();
            for (int i = 1; i <= numberOfColors; i++)
            {
                colors.Add(new Color(GetNumberBetween(color.R, otherColor.R, percentageStep * i),
                    GetNumberBetween(color.G, otherColor.G, percentageStep * i),
                    GetNumberBetween(color.B, otherColor.B, percentageStep * i),
                    GetNumberBetween(color.A, otherColor.A, percentageStep * i)));
            }
            return colors;
        }
        private static int GetNumberBetween(int number1, int number2, int percentage)
        {
            if (number1 == number2) return number1;
            percentage = Math.Clamp(percentage, 0, 100);
            var dif = Math.Abs(number1 - number2);
            var point = (int)Math.Floor(dif * percentage / 100d);
            return Math.Max(number1, number2) + point;
        }
    }
}
