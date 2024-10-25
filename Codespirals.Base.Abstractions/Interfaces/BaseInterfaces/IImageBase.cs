namespace Codespirals.Base
{
    public interface IImageBase : IHasUrl
    {
        /// <summary>
        /// A short description of what is in the image. Mainly to help people with impaired vision
        /// </summary>
        public string AltText { get; }
    }
}
