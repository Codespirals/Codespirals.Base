namespace Codespirals.Base;

public interface IDefaultable<TSelf>
    where TSelf : IDefaultable<TSelf>
{
    /// <summary>
    /// A staticly set default that can be returned instead when another value can't be retrieved
    /// </summary>
    /// <returns>A value of type <typeparamref name="TSelf"/> which represents the default value of the object returning it</returns>
    static abstract TSelf Default();
}
