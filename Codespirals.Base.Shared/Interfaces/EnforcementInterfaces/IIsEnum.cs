namespace Codespirals.Base;

/// <summary>
/// A class type implementing this is a selection of possible values.
/// It's basically a more elaborate version of <see cref="Enum"/>.
/// </summary>
public interface IIsEnum : ISelectableBase
{

}

/// <inheritdoc />
/// <typeparam name="TSelf">The type of the item implementing this</typeparam>
public interface IIsEnum<TSelf> : IIsEnum, IDefaultable<TSelf>
    where TSelf : IIsEnum<TSelf>
{

}
