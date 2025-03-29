namespace Codespirals.Base
{
    public interface ISelectableBase : IIdentifiable, INameable, IDescribable
    {
        /// <inheritdoc />
        public new string Id { get; init; }
        /// <inheritdoc />
        public new string Name { get; init; }
        /// <inheritdoc />
        public new string Description { get; init; }
    }
}
