namespace Codespirals.Base
{
    public interface IRelationshipBase<TRelationshipNatureValue>
        where TRelationshipNatureValue : ISelectableBase
    {
        public TRelationshipNatureValue Nature { get; }
    }
}
