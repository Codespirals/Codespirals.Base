namespace Codespirals.Base
{
    /// <summary>
    /// A class type implementing this is a selection of possible values.
    /// It's basically a more extensible version of <see cref="Enum"/>.
    /// </summary>
    /// <typeparam name="TSelf">The type of the item implementing this</typeparam>
    public interface IIsEnum<TSelf> : ISelectableBase, IDefaultable<TSelf>
        where TSelf : IIsEnum<TSelf>
    {

    }
}
