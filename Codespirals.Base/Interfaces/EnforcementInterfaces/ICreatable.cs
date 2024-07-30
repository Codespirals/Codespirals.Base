namespace Codespirals.Base.Interfaces
{
    /// <summary>
    /// Having this interface signifies the has a creation <see cref="DateTime"/>
    /// </summary>
    public interface ICreatable
    {
        /// <summary>
        /// The <see cref="DateTime"/> this item was created
        /// </summary>
        public DateTime Created { get; }
    }
}
