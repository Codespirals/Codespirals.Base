namespace Codespirals.Base
{
    public interface IOrderable
    {
        /// <summary>
        /// A number which helps a list get into a certain, fixed order
        /// </summary>
        public short Order { get; set; }
    }
}
