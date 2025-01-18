namespace Codespirals.Base
{
    public interface IDefaultable<T>
        where T : IDefaultable<T>
    {
        public T Default();
    }
}
