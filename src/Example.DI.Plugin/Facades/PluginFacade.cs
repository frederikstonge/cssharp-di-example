using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Facades;

/// <summary>
/// Plugin facade class
/// </summary>
public class PluginFacade : IPluginFacade
{
    private readonly ILogger _logger;
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Create instance of PluginFacade
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="httpClient">Http client</param>
    public PluginFacade(
        ILogger<PluginFacade> logger,
        HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }
}