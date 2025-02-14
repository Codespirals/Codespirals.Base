namespace Codespirals.Base.Components
{
    public partial class Image
    {
        private IImageBase image;
        public Image(IImageBase img)
        {
            image = img;
        }
    }
}
