using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Timers;
using Example.DI.Plugin.Extensions;
using Example.DI.Plugin.Models;
using Example.DI.Plugin.Services;

namespace Example.DI.Plugin;

public class Application : IApplication, IDisposable
{
    private readonly IBasePlugin _plugin;
    private readonly PluginConfig _config;
    private readonly IPluginService _pluginService;

    private CounterStrikeSharp.API.Modules.Timers.Timer? _timer;

    public Application(IBasePlugin plugin, PluginConfig config, IPluginService pluginService)
    {
        // Application class is where you create your event handlers and call services
        _plugin = plugin;
        _config = config;
        _pluginService = pluginService;
    }

    public void Initialize()
    {
        _plugin.AddCommand("test", "test method", Test);
        _plugin.RegisterListener<Listeners.OnMapStart>(OnMapStart);
        _plugin.RegisterEventHandler<EventPlayerDeath>(OnPlayerDeath);
        _timer = _plugin.AddTimer(0.25f, OnTimerTick, TimerFlags.REPEAT | TimerFlags.STOP_ON_MAPCHANGE);
    }

    public void Test(CCSPlayerController? client, CommandInfo commandInfo)
    {
    }

    public void OnMapStart(string mapName)
    {
    }

    public HookResult OnPlayerDeath(EventPlayerDeath @event, GameEventInfo gameEventInfo)
    {
        return HookResult.Continue;
    }

    public void OnTimerTick()
    {
    }

    public void Dispose()
    {
        _plugin.RemoveCommand("test", Test);
        _plugin.RemoveListener<Listeners.OnMapStart>(OnMapStart);
        _plugin.DeregisterEventHandler<EventPlayerDeath>(OnPlayerDeath);

        if (_timer != null)
        {
            _plugin.RemoveTimer(_timer);
            _timer = null;
        }
    }
}