namespace Codespirals.Base
{
    public interface IVisibility
    {
        public static abstract string Public { get; }
        public static abstract string Unlisted { get; }
        public static abstract string Private { get; }
        public static abstract string Hidden { get; }
    }
}
