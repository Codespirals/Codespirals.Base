namespace Codespirals.Base;

public interface IAddressBase
{
    /// <summary>
    /// A street with house number
    /// </summary>
    string Street { get; set; }
    /// <summary>
    /// A city
    /// </summary>
    string City { get; set; }
    /// <summary>
    /// A postal or zip code
    /// </summary>
    string ZipCode { get; set; }
    /// <summary>
    /// The country
    /// </summary>
    string Country { get; set; }
}
