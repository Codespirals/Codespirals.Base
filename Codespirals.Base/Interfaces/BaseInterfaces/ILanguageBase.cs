using System.Globalization;

namespace Codespirals.Base.Interfaces
{
    public interface ILanguageBase : INameable
    {
        /// <summary>
        /// Turn this <see cref="ILanguageBase"/> item into a <see cref="CultureInfo"/>
        /// </summary>
        /// <returns></returns>
        public CultureInfo ToCultureInfo();
    }
}
