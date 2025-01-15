namespace Codespirals.Base
{
    public interface IRelationshipNature : IRelationshipNature<int>
    {

    }
    public interface IRelationshipNature<TValue>
        where TValue : IComparable
    {
        public abstract static TValue None { get; }
        public abstract static TValue Saved { get; }
        public abstract static TValue Hidden { get; }
        public abstract static TValue Blocked { get; }
    }
}
