namespace Codespirals.Base
{
    /// <summary>
    /// A simple base type to be generically used for things like enums and drop downs
    /// </summary>
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
