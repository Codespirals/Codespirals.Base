namespace Codespirals.Base
{
    public interface IRelationshipBase<TRelationshipNature, TRelationshipNatureValue>
        where TRelationshipNature : IRelationshipNature<TRelationshipNatureValue>
        where TRelationshipNatureValue : IComparable
    {
        public TRelationshipNatureValue Nature { get; }
        public bool IsBlock { get; }
    }
}
