namespace Codespirals.Base
{
    /// <summary>
    /// A class type implementing this is a selection of possible values
    /// </summary>
    /// <typeparam name="TSelf"></typeparam>
    public interface IIsEnum<TSelf> : ISelectableBase
        where TSelf : IIsEnum<TSelf>
    {
        /// <summary>
        /// A staticly set default that can be returned instead when another value can't be retrieved
        /// </summary>
        /// <returns>A value of type <typeparamref name="TSelf"/> which represents the default value of the object returning it</returns>
        public static abstract TSelf Default();
    }
}
