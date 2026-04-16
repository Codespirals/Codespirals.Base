namespace Codespirals.Base.Logging;

/// <summary>
/// States a log can be in
/// </summary>
public enum State
{
    /// <summary>
    /// 
    /// </summary>
    Started,
    /// <summary>
    /// 
    /// </summary>
    InProgress,
    /// <summary>
    /// 
    /// </summary>
    Success = 200,
    /// <summary>
    /// 
    /// </summary>
    ActionSkipped = 201,
    /// <summary>
    /// 
    /// </summary>
    Cancelled = 300,
    /// <summary>
    /// 
    /// </summary>
    Stopped = 400
}
