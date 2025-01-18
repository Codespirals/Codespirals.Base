namespace Codespirals.Base
{
    public interface IRelationshipBase<TRelationshipNature>
        where TRelationshipNature : IRelationshipNature
    {
        public string Nature { get; }
    }
}
