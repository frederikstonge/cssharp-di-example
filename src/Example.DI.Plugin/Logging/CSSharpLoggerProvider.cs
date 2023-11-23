using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Logging;

public class CSSharpLoggerProvider : ILoggerProvider
{
    private readonly ILogger _logger;

    public CSSharpLoggerProvider(ILogger logger)
    {
        _logger = logger;
    }

    public ILogger CreateLogger(string categoryName) => _logger;

    public void Dispose()
    {
    }
}