namespace Codespirals.Base
{
    public interface IResult<TData, TError>
    {
        public TError? Error { get; }
        public TData? Data { get; }
    }
}
