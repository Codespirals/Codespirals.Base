using System.Globalization;
using System.Resources;

namespace Codespirals.Base
{
    public static class LocalizedStringExtensions
    {
        public static string ToString(this ILocalizedStringBase localizableResource, string isoCode)
        {
            var cultureInfo = CultureInfo.GetCultureInfo(isoCode);
            var resourceManager = new ResourceManager(localizableResource.ResourceType);
            var resource = resourceManager.GetString(localizableResource.ResourceName, cultureInfo);
            if (resource == null) { return string.Empty; }
            return resource;
        }
        public static string ToString(this ILocalizedStringBase localizableResource, CultureInfo cultureInfo)
        {
            var resourceManager = new ResourceManager(localizableResource.ResourceType);
            var resource = resourceManager.GetString(localizableResource.ResourceName, cultureInfo);
            if (resource == null) { return string.Empty; }
            return resource;
        }
    }
}
