namespace Codespirals.Base.Interfaces
{
    public interface IAddressBase<TCountry> : INameable
    {
        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }
        public string Country { get; }
    }
}
