using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Codespirals.Base;

public static class LoggingExtensions
{
    public static IDisposable? BeginLog(this ILogger logger, string service, string method, params object[]? args)
    {
        try
        {
            if (logger is null) { return null; }
            var processId = Guid.NewGuid().ToString();
            var scope = logger.BeginScope(BuildScope(processId, service, method));
            var message = args is not null ? string.Join("\r\n", args.Select(arg => $"{nameof(arg)}: {JsonSerializer.Serialize(arg)}")) : "";
            message = $"\r\n{JsonSerializer.Serialize(args)}";
            logger.LogInformation("Logging {method}.\r\n{message}", method, message);
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
        InProgress,
        ActionSkipped,
        Success,
        Cancelled,
        Stopped
    }
    private static Dictionary<string, string> BuildScope(string processId, string service, string method, string? sessionId = null)
    {
        var scopeItems = new Dictionary<string, string>();
        if (string.IsNullOrWhiteSpace(sessionId)) { scopeItems.Add("SessionId", nameof(sessionId)); }
        scopeItems.Add("ProcessId", processId);
        if (!string.IsNullOrWhiteSpace(service)) { scopeItems.Add("Service", nameof(service)); }
        if (!string.IsNullOrWhiteSpace(method)) { scopeItems.Add("Method", nameof(method)); }
        return scopeItems;
    }
}
