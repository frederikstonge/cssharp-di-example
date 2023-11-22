using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Timers;
using Example.DI.Plugin.Factories;
using Example.DI.Plugin.Models;
using Example.DI.Plugin.Services;
using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin;

/// <summary>
/// Application class
/// </summary>
public class Application : IApplication
{
    private readonly ILogger _logger;
    private readonly IExamplePlugin _plugin;
    private readonly PluginConfig _config;
    private readonly IPluginService _pluginService;
    private readonly ITestServiceFactory _testServiceFactory;

    /// <summary>
    /// Create instance of Application
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="plugin">Plugin reference</param>
    /// <param name="config">Parsed config</param>
    /// <param name="pluginService">Plugin service</param>
    public Application(
        ILogger<Application> logger,
        IExamplePlugin plugin,
        PluginConfig config,
        IPluginService pluginService,
        ITestServiceFactory testFactory)
    {
        _logger = logger;
        _plugin = plugin;
        _config = config;
        _pluginService = pluginService;
        _testServiceFactory = testFactory;
    }

    public ITestService? TestService { get; private set; }

    /// <summary>
    /// Initialize event registrations and more
    /// </summary>
    public void Initialize()
    {
        TestService = _testServiceFactory.Create("Service 1");
        
        _plugin.AddCommand("test", "test method", Test);
        _plugin.RegisterListener<Listeners.OnMapStart>(OnMapStart);
        _plugin.RegisterEventHandler<EventPlayerDeath>(OnPlayerDeath);
        _plugin.AddTimer(0.25f, OnTimerTick, TimerFlags.REPEAT | TimerFlags.STOP_ON_MAPCHANGE);
    }

    /// <summary>
    /// Callback of command `test`
    /// </summary>
    /// <param name="client">The player's controller reference</param>
    /// <param name="commandInfo">Command information</param>
    private void Test(CCSPlayerController? client, CommandInfo commandInfo)
    {
    }

    /// <summary>
    /// Callback of registered listener `OnMapStart`
    /// </summary>
    /// <param name="mapName"></param>
    private void OnMapStart(string mapName)
    {
    }

    /// <summary>
    /// Callback of registered event handler `EventPlayerDeath`
    /// </summary>
    /// <param name="event">The event reference</param>
    /// <param name="gameEventInfo">Event information</param>
    /// <returns></returns>
    private HookResult OnPlayerDeath(EventPlayerDeath @event, GameEventInfo gameEventInfo)
    {
        return HookResult.Continue;
    }

    /// <summary>
    /// Callback called on timer tick
    /// </summary>
    private void OnTimerTick()
    {
    }
}