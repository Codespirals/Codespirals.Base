namespace Codespirals.Base;

/// <summary>
/// An object implementing this has a way to summarize the data contained within
/// </summary>
/// <typeparam name="TSummary"></typeparam>
public interface ISummarizable<TSummary>
    where TSummary : ISummary
{
    /// <summary>
    /// Create a summary of this object
    /// </summary>
    /// <returns></returns>
    TSummary Summarize();
}
