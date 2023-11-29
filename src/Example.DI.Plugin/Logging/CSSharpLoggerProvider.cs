using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Logging;

public class CSSharpLoggerProvider : ILoggerProvider
{
    public CSSharpLoggerProvider()
    {
    }

    public ILogger CreateLogger(string categoryName) => CounterStrikeSharp.API.Core.Logging.CoreLogging.Factory.CreateLogger(categoryName);

    public void Dispose()
    {
    }
}