namespace Codespirals.Base
{
    public interface IRelationshipBase<TRelationshipNature, TRelationshipNatureValue>
        where TRelationshipNature : IRelationshipNature<TRelationshipNatureValue>
        where TRelationshipNatureValue : ISelectableBase
    {
        public TRelationshipNatureValue Nature { get; }
    }
}
