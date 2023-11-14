using Example.DI.Plugin.Facades;

namespace Example.DI.Plugin.Services;

public class PluginService : IPluginService
{
    private readonly IPluginFacade _pluginFacade;

    public PluginService(IPluginFacade pluginFacade)
    {
        // Plugin service example that will be injected in the Application class
        _pluginFacade = pluginFacade;
    }
}