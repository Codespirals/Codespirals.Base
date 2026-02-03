using Microsoft.Extensions.Logging;

namespace Codespirals.Base;

/// <summary>
/// Extensions on <see cref="ILogger"/>
/// </summary>
public static class LoggingExtensions
{
    /// <summary>
    /// Start a logging session
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="method"></param>
    /// <param name="additionalArguments">A list of arguments to be added to the scope</param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static IDisposable? BeginLog(this ILogger logger, string method, Dictionary<string, string>? additionalArguments = null, string? message = null)
    {
        try
        {
            var processId = Guid.NewGuid().ToString();
            var scope = logger.BeginScope(BuildScope(processId, method, additionalArguments));
            message ??= "Beginning new log";
            logger.LogStep(State.Started, message);
            return scope;
        }
        catch (Exception ex)
        {
            logger.LogError("Critical fail when starting a log scope!\r\n{message}", ex.Message);
            return null;
        }
    }
    /// <summary>
    /// Log a step in the process
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="state"></param>
    /// <param name="message"></param>
    public static void LogStep(this ILogger logger, State state, string? message = null)
        => logger.LogInformation("{state}{message}", state, message is not null ? $"\r\n{message}" : "");

    /// <summary>
    /// Log an exception happening
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="state"></param>
    /// <param name="exception"></param>
    public static void LogException(this ILogger logger, State state, Exception exception)
        => logger.LogCritical(exception, "Exception triggered! Current state of operation: {state}\r\n{message}", state, exception.Message);

    /// <summary>
    /// States an operation can be in
    /// </summary>
    public enum State
    {
        Started,
        InProgress,
        ActionSkipped,
        Success,
        Cancelled,
        Stopped
    }
    private static Dictionary<string, string> BuildScope(string processId, string service, Dictionary<string, string>? additionalArguments = null)
    {
        var scopeItems = new Dictionary<string, string>
        {
            { "ProcessId", processId }
        };
        if (!string.IsNullOrWhiteSpace(service)) { scopeItems.Add("Method", nameof(service)); }
        if (additionalArguments is not null)
            foreach (var argument in additionalArguments)
                if (!string.IsNullOrWhiteSpace(argument.Key) && !string.IsNullOrWhiteSpace(argument.Value)) { scopeItems.Add(argument.Key, argument.Value); }
        return scopeItems;
    }
}
