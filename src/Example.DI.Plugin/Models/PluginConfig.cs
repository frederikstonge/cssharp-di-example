using CounterStrikeSharp.API.Core;

namespace Example.DI.Plugin.Models;

public class PluginConfig : BasePluginConfig
{
    public bool IsEnabled { get; set; } = true;
}