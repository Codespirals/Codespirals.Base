namespace Codespirals.Base
{
    public interface IRelationship<TRelationshipNatureValue>
        where TRelationshipNatureValue : ISelectableBase
    {
        public TRelationshipNatureValue Nature { get; }
    }
}
