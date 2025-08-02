namespace Codespirals.Base
{
    public interface IInternalToken<TType> : ITokenBase, ICreatable
    {
        public int InvalidAttempts { get; }
        public int? MaxInvalidAttempts { get; }
    }
}
