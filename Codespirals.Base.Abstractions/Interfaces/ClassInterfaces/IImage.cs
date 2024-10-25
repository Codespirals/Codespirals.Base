namespace Codespirals.Base
{
    public interface IImage : IImageBase, IIdentifiable
    {
        /// <summary>
        /// Credit to the entity that made the image
        /// </summary>
        public string Credit { get; }
    }
}
