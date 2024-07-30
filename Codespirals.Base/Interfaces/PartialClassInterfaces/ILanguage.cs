using System.Globalization;

namespace Codespirals.Base.Interfaces
{
    public interface ILanguage : INameable
    {
        /// <summary>
        /// Turn this <see cref="ILanguage"/> item into a <see cref="CultureInfo"/>
        /// </summary>
        /// <returns></returns>
        public CultureInfo ToCultureInfo();
    }
}
