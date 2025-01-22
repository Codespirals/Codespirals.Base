namespace Codespirals.Base
{
    public partial interface IRelationshipNatures<TValue> : IIsEnum<TValue>
        where TValue : ISelectableBase
    {
        public abstract static TValue None { get; }
    }
}
