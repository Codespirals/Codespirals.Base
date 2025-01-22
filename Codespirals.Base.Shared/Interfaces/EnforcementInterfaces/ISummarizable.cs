namespace Codespirals.Base
{
    /// <summary>
    /// This interface is used to summarize an object.
    /// </summary>
    /// <typeparam name="TSummary"></typeparam>
    public interface ISummarizable<TSummary>
        where TSummary : ISummary
    {
        public TSummary Summarize();
    }
}
