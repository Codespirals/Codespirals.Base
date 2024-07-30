namespace Codespirals.Base.Interfaces
{
    public interface IImageBase
    {
        /// <summary>
        /// The url that leads to the image
        /// </summary>
        public string Url { get; }
        /// <summary>
        /// A short description of what is in the image. Mainly to help people with impaired vision
        /// </summary>
        public string AltText { get; }
    }
}
