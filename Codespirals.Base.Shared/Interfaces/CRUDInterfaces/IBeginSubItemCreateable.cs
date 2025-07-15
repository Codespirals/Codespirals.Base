namespace Codespirals.Base
{
    /// <summary>
    /// A service implementing this interface requires the api to have a method to retrieve an object of the create type for a given class
    /// </summary>
    /// <typeparam name="TCreate">The create object</typeparam>
    /// <remarks>
    /// This interface is in almost all cases optional and could even be seen as an unecessary
    /// call to the Api, however implementing it makes it easy to go through all createion steps
    /// by using nothing but the SDK implementing this, which can be a bonus
    /// </remarks>
    public interface IBeginSubItemCreateable<TCreate>
    {
        /// <summary>
        /// Request a create object to start creating a new item with
        /// </summary>
        /// <returns>The create object</returns>
        public TCreate BeginCreate(string parentId);
    }
    /// <inheritdoc />
    public interface IBeginSubItemCreateableAsync<TCreate>
    {
        /// <summary>
        /// Request a create object to start creating a new item with
        /// </summary>
        /// <returns>The create object</returns>
        public Task<TCreate> BeginCreateAsync(string parentId);
    }
}
