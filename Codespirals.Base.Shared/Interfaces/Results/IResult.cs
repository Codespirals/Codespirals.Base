namespace Codespirals.Base
{
    public interface IResult<TSelf> : IResultBase<TSelf>
        where TSelf : IResult<TSelf>
    {
        public abstract static TSelf Ok();
        public abstract static TSelf Fail(string error, int errorCode = 0);
    }
    /// <summary>
    /// A full result with data
    /// </summary>
    /// <typeparam name="TData">The type of the data</typeparam>
    public interface IResult<TSelf, TData> : IResultBase<TSelf, TData>
        where TSelf : IResult<TSelf, TData>
    {
        public abstract static TSelf Ok(TData data);
        public abstract static TSelf Fail(string error, int errorCode = 0);
    }
}
