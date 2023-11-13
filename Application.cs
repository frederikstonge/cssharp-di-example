using Plugin.DI.Models;
using Plugin.DI.Services;

namespace Plugin.DI;

public class Application : IApplication
{
    private readonly Plugin _plugin;
    private readonly PluginConfig _config;
    private readonly PluginService _pluginService;

    public Application(Plugin plugin, PluginConfig config, PluginService pluginService)
    {
        _plugin = plugin;
        _config = config;
        _pluginService = pluginService;
    }
}