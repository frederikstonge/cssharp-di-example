using Example.DI.Plugin.Facades;

namespace Example.DI.Plugin.Services;

public class PluginService : IPluginService
{
    private readonly IPluginFacade _pluginFacade;

    public PluginService(IPluginFacade pluginFacade)
    {
        _pluginFacade = pluginFacade;
    }
}