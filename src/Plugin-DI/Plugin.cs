using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Plugin.DI.Models;
using Plugin.DI.Services;

namespace Plugin.DI;

[MinimumApiVersion(50)]
public class Plugin : BasePlugin, IPluginConfig<PluginConfig>, IBasePlugin
{
    private ServiceProvider? _serviceProvider;
    private IApplication? _application;
    private PluginConfig? _config;

    public override string ModuleName => "Plugin-DI";
    
    public override string ModuleDescription => "Example plugin with dependency injection";

    public override string ModuleVersion => "0.0.1";

    public override string ModuleAuthor => "frederikstonge";

    public PluginConfig Config 
    {
        get => _config ?? throw new NullReferenceException(nameof(Config));
        set => _config = value; 
    }

    public void OnConfigParsed(PluginConfig config)
    {
        Config = config;
    }

    public override void Load(bool hotReload)
    {
        base.Load(hotReload);

        var services = new ServiceCollection();
        services.AddSingleton<IBasePlugin>(this);
        services.AddSingleton(Config);
        services.AddSingleton<IApplication, Application>();

        // Register other services here
        services.AddSingleton<IPluginService, PluginService>();

        _serviceProvider = services.BuildServiceProvider();

        // Instantiate Application class where event handlers and other things will be declared
        _application = _serviceProvider.GetRequiredService<IApplication>();
    }

    public override void Unload(bool hotReload)
    {
        // Remove reference before disposing the service provider
        _application = null;

        _serviceProvider?.Dispose();
        _serviceProvider = null;

        base.Unload(hotReload);
    }
}