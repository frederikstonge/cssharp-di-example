using Example.DI.Plugin.Facades;
using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Services;

public class PluginService : IPluginService
{
    private readonly ILogger _logger;
    private readonly IPluginFacade _pluginFacade;

    public PluginService(
        ILogger<PluginService> logger,
        IPluginFacade pluginFacade)
    {
        _logger = logger;
        _pluginFacade = pluginFacade;
    }
}