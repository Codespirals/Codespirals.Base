namespace Codespirals.Base
{
    public interface IVisibility<TSelf>
        where TSelf : IVisibility<TSelf>
    {
        public static abstract TSelf Public { get; }
        public static abstract TSelf Unlisted { get; }
        public static abstract TSelf Private { get; }
        public static abstract TSelf Hidden { get; }
    }
}
