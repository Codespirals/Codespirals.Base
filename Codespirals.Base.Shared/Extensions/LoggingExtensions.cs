using Microsoft.Extensions.Logging;

namespace Codespirals.Base.Logging;

/// <summary>
/// Extensions on <see cref="ILogger"/>
/// </summary>
public static partial class LoggingExtensions
{
    /// <summary>
    /// Start a logging session
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="function"></param>
    /// <param name="additionalArguments">A list of arguments to be added to the scope</param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static IDisposable? BeginLog(this ILogger logger, string function, string? message = null, params (string, string)[] additionalArguments)
    {
        try
        {
            var scopeString = string.Join('\n', BuildScope(function, additionalArguments).Select(x => $"{x.Key}:{x.Value}"));
            var scope = logger.BeginScope(scopeString);
            logger.LogStep(State.Started, message ??= "Beginning new log"); 
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
    private static Dictionary<string, string> BuildScope(string function, params (string, string)[] additionalArguments)
    {
        Dictionary<string, string> scopeItems = new()
        {
            { "ProcessId", Guid.NewGuid().ToString() }
        };
        if (!string.IsNullOrWhiteSpace(function)) { scopeItems.Add("Method", nameof(function)); }
        if (additionalArguments is not null)
            foreach (var argument in additionalArguments)
                if (!string.IsNullOrWhiteSpace(argument.Item1) && !string.IsNullOrWhiteSpace(argument.Item2)) { scopeItems.Add(argument.Item1, argument.Item2); }
        return scopeItems;
    }
}
