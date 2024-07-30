using System.Globalization;

namespace Codespirals.Generic.Interfaces
{
    public interface ILanguage : IIdentifiable, INameable
    {
        /// <summary>
        /// Turn this <see cref="ILanguage"/> item into a <see cref="CultureInfo"/>
        /// </summary>
        /// <returns></returns>
        public CultureInfo ToCultureInfo();
    }
}
