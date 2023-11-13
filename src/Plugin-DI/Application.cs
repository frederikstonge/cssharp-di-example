using Plugin.DI.Models;
using Plugin.DI.Services;

namespace Plugin.DI;

public class Application : IApplication
{
    private readonly Plugin _plugin;
    private readonly PluginConfig _config;
    private readonly IPluginService _pluginService;

    public Application(Plugin plugin, PluginConfig config, IPluginService pluginService)
    {
        // Application class is where you create your event handlers and call services
        _plugin = plugin;
        _config = config;
        _pluginService = pluginService;
    }
}