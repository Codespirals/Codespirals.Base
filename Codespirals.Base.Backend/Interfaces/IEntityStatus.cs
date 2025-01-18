namespace Codespirals.Base
{
    public interface IEntityStatus
    {
        public static abstract string Unset { get; }
        public static abstract string Normal { get; }
        public static abstract string Flagged { get; }
        public static abstract string Deleted { get; }
    }
}
