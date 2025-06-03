namespace Codespirals.Base
{
    public interface IInternalToken<TType> : ITokenBase, ICreatable
    {
        public TType TokenType { get; }
        public int? MinutesToLive { get; }
        public bool IsValid { get; }
        public int InvalidAttempts { get; }
        public int MaxInvalidAttempts { get; }
    }
}
