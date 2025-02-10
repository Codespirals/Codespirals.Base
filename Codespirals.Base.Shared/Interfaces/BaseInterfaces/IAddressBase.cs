namespace Codespirals.Base
{
    public interface IAddressBase : INameable
    {
        public new string Name { get; set; }
        /// <summary>
        /// A street with house number
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// A city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// A postal or zip code
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// The country
        /// </summary>
        public string Country { get; set; }
    }
}
