using Microsoft.Extensions.Logging;

namespace Codespirals.Base;

public static class LoggingExtensions
{
    public static IDisposable? BeginLog(this ILogger logger, string? service = null, Dictionary<string, string>? additionalArguments = null, string? message = null)
    {
        try
        {
            var processId = Guid.NewGuid().ToString();
            var scope = logger.BeginScope(BuildScope(processId, service, additionalArguments));
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
    public static void LogStep(this ILogger logger, State state, string? message = null)
        => logger.LogInformation("Current state of operation: {state}{message}", state, message is not null ? $"\r\n{message}" : "");

    public static void LogException(this ILogger logger, State state, Exception exception)
        => logger.LogCritical(exception, "Exception triggered! Current state of operation: {state}\r\n{message}", state, exception.Message);

    public enum State
    {
        Started,
        InProgress,
        ActionSkipped,
        Success,
        Cancelled,
        Stopped
    }
    private static Dictionary<string, string> BuildScope(string processId, string? service = null, Dictionary<string, string>? additionalArguments = null)
    {
        var scopeItems = new Dictionary<string, string>
        {
            { "ProcessId", processId }
        };
        if (!string.IsNullOrWhiteSpace(service)) { scopeItems.Add("Service", nameof(service)); }
        if (additionalArguments is not null)
            foreach (var argument in additionalArguments)
                if (!string.IsNullOrWhiteSpace(argument.Key) && !string.IsNullOrWhiteSpace(argument.Value)) { scopeItems.Add(argument.Key, argument.Value); }
        return scopeItems;
    }
}
