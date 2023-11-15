using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Facades;

public class PluginFacade : IPluginFacade
{
    private readonly ILogger _logger;
    private readonly HttpClient _httpClient;

    public PluginFacade(
        ILogger<PluginFacade> logger,
        HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }
}