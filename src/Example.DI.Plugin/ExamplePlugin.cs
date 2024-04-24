using System.Reflection;
using CounterStrikeSharp.API.Core;
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
public class ExamplePlugin : BasePlugin, IExamplePlugin
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly string _moduleVersion;
    private ServiceProvider? _serviceProvider;
    private IApplication? _application;

    /// <summary>
    /// Create instance of ExamplePlugin
    /// </summary>
    public ExamplePlugin(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
        _moduleVersion = typeof(ExamplePlugin)
                         .Assembly!
                         .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
                         .InformationalVersion;
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
    /// Method that is called on load of the plugin
    /// </summary>
    /// <param name="hotReload">Is called from hot reload</param>
    public override void Load(bool hotReload)
    {
        base.Load(hotReload);

        // Create DI container
        var services = new ServiceCollection();

        // Add configuration
        services
            .AddOptions<PluginConfig>()
            .BindConfiguration(string.Empty)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Add localization
        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });

        // Add logging
        services.AddSingleton(_loggerFactory);
        services.AddLogging();

        // Add the plugin instance
        services.AddSingleton<IExamplePlugin>(this);

        // Register Application
        services.AddSingleton<IApplication, Application>();

        // Register factories here
        services.AddSingleton<ITestServiceFactory, TestServiceFactory>();

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