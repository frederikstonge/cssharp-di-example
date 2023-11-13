using CounterStrikeSharp.API.Core;

namespace Example.DI.Plugin.Models;

public class PluginConfig : IBasePluginConfig
{
    public int Version { get; set; }
}