namespace Codespirals.Base
{
    public interface IDefaultable<TSelf>
        where TSelf : IDefaultable<TSelf>
    {
        public TSelf Default();
    }
}
