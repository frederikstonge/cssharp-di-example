using Example.DI.Plugin.Facades;
using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Services;

/// <summary>
/// Plugin service class
/// </summary>
public class PluginService : IPluginService
{
    private readonly ILogger _logger;
    private readonly IPluginFacade _pluginFacade;

    /// <summary>
    /// Create instance of PluginService
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="pluginFacade">Plugin facade</param>
    public PluginService(
        ILogger<PluginService> logger,
        IPluginFacade pluginFacade)
    {
        _logger = logger;
        _pluginFacade = pluginFacade;
    }
}