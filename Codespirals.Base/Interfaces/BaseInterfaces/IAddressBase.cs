namespace Codespirals.Base
{
    public interface IAddressBase : INameable
    {
        /// <summary>
        /// A street with house number
        /// </summary>
        public string Street { get; }
        /// <summary>
        /// A city
        /// </summary>
        public string City { get; }
        /// <summary>
        /// A postal or zip code
        /// </summary>
        public string ZipCode { get; }
        /// <summary>
        /// The country
        /// </summary>
        public string Country { get; }
    }
}
