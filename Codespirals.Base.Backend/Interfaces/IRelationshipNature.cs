namespace Codespirals.Base
{
    public interface IRelationshipNature
    {
        public abstract static string None { get; }
        public abstract static string Saved { get; }
        public abstract static string Hidden { get; }
        public abstract static string Blocked { get; }
    }
}
