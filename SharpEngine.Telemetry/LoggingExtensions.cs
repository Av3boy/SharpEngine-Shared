using Microsoft.Extensions.Logging;

namespace SharpEngine.Telemetry;

/// <summary>
///     Contains extensions for logging messages.
/// </summary>
public static class LoggingExtensions
{
    /// <summary>
    ///     Creates a logger with console output for the specified type.
    /// </summary>
    /// <typeparam name="T">The type for which to create the logger.</typeparam>
    /// <param name="logLevel">The minimum log level for the logger.</param>
    /// <returns>A logger instance configured with console logging.</returns>
    public static ILogger<T> CreateLogger<T>(LogLevel logLevel = LogLevel.Information)
        => LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(logLevel)).CreateLogger<T>();

    /// <summary>
    ///     Creates a logger with console output for the specified type.
    /// </summary>
    /// <param name="type">The type for which to create the logger.</param>
    /// <param name="logLevel">The minimum log level for the logger.</param>
    /// <returns>A logger instance configured with console logging.</returns>
    public static ILogger CreateLogger(Type type, LogLevel logLevel = LogLevel.Information)
        => LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(logLevel)).CreateLogger(type);
}
