using System.Reflection;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using Example.DI.Plugin.Facades;
using Example.DI.Plugin.Factories;
using Example.DI.Plugin.Models;
using Example.DI.Plugin.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin;

/// <summary>
/// Example plugin class
/// </summary>
[MinimumApiVersion(66)]
public class ExamplePlugin : BasePlugin, IExamplePlugin, IPluginConfig<PluginConfig>
{
    private readonly string _moduleVersion;
    private ServiceProvider? _serviceProvider;
    private PluginConfig? _config;
    private IApplication? _application; 

    /// <summary>
    /// Create instance of ExamplePlugin
    /// </summary>
    public ExamplePlugin()
    {
        _moduleVersion = typeof(ExamplePlugin).Assembly!.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
    }

    /// <summary>
    /// Module name that will be displayed in CSSharp
    /// </summary>
    public override string ModuleName => "Example DI";
    
    /// <summary>
    /// Module description that will be displayed in CSSharp
    /// </summary>
    public override string ModuleDescription => "Example plugin with dependency injection";

    /// <summary>
    /// Module version that will be displayed in CSSharp
    /// </summary>
    public override string ModuleVersion => _moduleVersion;

    /// <summary>
    /// Module author that will be displayed in CSSharp
    /// </summary>
    public override string ModuleAuthor => "frederikstonge";

    /// <summary>
    /// Config that is parsed by CSSharp
    /// </summary>
    public PluginConfig Config 
    {
        get => _config ?? throw new NullReferenceException(nameof(Config));
        set => _config = value; 
    }

    /// <summary>
    /// Called when the config is parsed by CSSharp
    /// </summary>
    /// <param name="config">Parsed config</param>
    public void OnConfigParsed(PluginConfig config)
    {
        Config = config;
    }

    /// <summary>
    /// Method that is called on load of the plugin
    /// </summary>
    /// <param name="hotReload">Is called from hot reload</param>
    public override void Load(bool hotReload)
    {
        base.Load(hotReload);

        if (!Config.IsEnabled)
        {
            return;
        }

        // Create DI container
        var services = new ServiceCollection();

        services.AddLogging(options => 
        {
            options.AddConsole();
        });

        services.AddSingleton<IExamplePlugin>(this);
        services.AddSingleton(Config);
        services.AddSingleton<IApplication, Application>();

        // Register factories here
        services.AddSingleton<ITestFactory, TestFactory>();

        // Register other services here
        services.AddSingleton<IPluginService, PluginService>();
        
        // Register facades here (Services that have an httpclient)
        services.AddHttpClient<IPluginFacade, PluginFacade>();

        // Build service provider
        _serviceProvider = services.BuildServiceProvider();

        // Instantiate Application class where event handlers and other things will be declared
        _application = _serviceProvider.GetRequiredService<IApplication>();
        _application.Initialize();
    }

    /// <summary>
    /// Method that is called on unload of the plugin
    /// </summary>
    /// <param name="hotReload">Is called from hot reload</param>
    public override void Unload(bool hotReload)
    {
        // Remove reference
        _application = null;

        // Dispose service provider
        _serviceProvider?.Dispose();
        _serviceProvider = null;

        base.Unload(hotReload);
    }
}