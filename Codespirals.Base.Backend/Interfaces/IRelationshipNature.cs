namespace Codespirals.Base
{
    public partial interface IRelationshipNature<TValue> : IIsEnum
        where TValue : ISelectableBase
    {
        public abstract static TValue None { get; }
        public abstract static TValue Saved { get; }
        public abstract static TValue Hidden { get; }
        public abstract static TValue Blocked { get; }
    }
}
