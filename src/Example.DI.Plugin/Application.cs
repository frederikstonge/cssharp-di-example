using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Timers;
using Example.DI.Plugin.Models;
using Example.DI.Plugin.Services;

namespace Example.DI.Plugin;

public class Application : IApplication
{
    private readonly IBasePlugin _plugin;
    private readonly PluginConfig _config;
    private readonly IPluginService _pluginService;

    public Application(IBasePlugin plugin, PluginConfig config, IPluginService pluginService)
    {
        _plugin = plugin;
        _config = config;
        _pluginService = pluginService;
    }

    public void Initialize()
    {
        _plugin.AddCommand("test", "test method", Test);
        _plugin.RegisterListener<Listeners.OnMapStart>(OnMapStart);
        _plugin.RegisterEventHandler<EventPlayerDeath>(OnPlayerDeath);
        _plugin.AddTimer(0.25f, OnTimerTick, TimerFlags.REPEAT | TimerFlags.STOP_ON_MAPCHANGE);
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
}