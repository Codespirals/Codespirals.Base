namespace Codespirals.Base
{
    public interface ISelectableBase : IIdentifiable, INameable, IDescribable
    {
        public new string Id { get; init; }
        public new string Name { get; init; }
        public new string Description { get; init; }
    }
}
