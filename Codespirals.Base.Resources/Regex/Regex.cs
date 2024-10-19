using System.Text.RegularExpressions;

namespace Codespirals.Base
{
    public static partial class RegexExtensions
    {
        [GeneratedRegex("^#?(?:[0-9a-fA-F]{3,4}){1,2}$")]
        public static partial Regex IsHexColorValue();
    }
}
