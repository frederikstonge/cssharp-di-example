using CounterStrikeSharp.API.Core;

namespace Plugin.DI.Models;

public class PluginConfig : IBasePluginConfig
{
    public int Version { get; set; }
}