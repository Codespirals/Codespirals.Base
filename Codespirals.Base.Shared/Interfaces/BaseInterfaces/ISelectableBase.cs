namespace Codespirals.Base
{
    /// <summary>
    /// A simple base type to be generically used for things like enums and drop downs
    /// </summary>
    /// <remarks>
    /// A class implementing this type ensures it has 
    /// <list type="bullet">
    /// <item>A unique id that can be used to select an item</item>
    /// <item>A name that can be displayed</item>
    /// <item>A usually optional description to further describe the item</item>
    /// </list>
    /// </remarks>
    public interface ISelectableBase : ISelectableBase<string>
    {

    }
    /// <inheritdoc cref="ISelectableBase"/>
    /// <typeparam name="TId">The type of the Id property</typeparam>
    public interface ISelectableBase<TId> : IIdentifiable<TId>, INameable, IDescribable
    {
        
    }
}
