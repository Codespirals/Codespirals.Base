namespace Codespirals.Base
{
    /// <summary>
    /// A class type implementing this is a selection of possible values
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IIsEnum<TValue>
        where TValue : ISelectableBase
    {
        /// <summary>
        /// A staticly set default that can be returned instead when another value can't be retrieved
        /// </summary>
        /// <returns>A value of type <typeparamref name="TValue"/> which represents the default value of the object returning it</returns>
        public static abstract TValue Default();
    }
}
