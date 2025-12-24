namespace Codespirals.Base;

/// <summary>
/// Classes implementing this can have a forced, fixed order when in a list
/// </summary>
public interface IOrderable
{
    /// <summary>
    /// A number which helps a list get into a certain, fixed order
    /// </summary>
    public short Order { get; set; }
}
