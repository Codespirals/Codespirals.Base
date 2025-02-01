namespace Codespirals.Base
{
    public interface IIsEnum<TValue>
        where TValue : ISelectableBase
    {
        public static abstract TValue Default();
    }
}
