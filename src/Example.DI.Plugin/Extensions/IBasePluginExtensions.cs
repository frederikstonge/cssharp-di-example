using System.Reflection;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Modules.Events;
using static CounterStrikeSharp.API.Core.BasePlugin;

namespace Example.DI.Plugin.Extensions;

public static class IBasePluginExtensions 
{
    public static void RemoveListener<T>(this IBasePlugin plugin, T handler) 
        where T : Delegate
    {
        var listenerName = typeof(T).GetCustomAttribute<ListenerNameAttribute>()?.Name;
        if (string.IsNullOrEmpty(listenerName))
        {
            throw new Exception("Listener of type T is invalid and does not have a name attribute");
        }

        plugin.RemoveListener(listenerName, handler);
    }

    public static void DeregisterEventHandler<T>(this IBasePlugin plugin, GameEventHandler<T> handler, HookMode hookMode = HookMode.Post) 
        where T : GameEvent
    {
        var eventName = typeof(T).GetCustomAttribute<EventNameAttribute>()?.Name;
        if (string.IsNullOrEmpty(eventName))
        {
            throw new Exception("Event of type T is invalid and does not have a name attribute");
        }

        plugin.DeregisterEventHandler(eventName, handler, hookMode == HookMode.Post);
    }
}