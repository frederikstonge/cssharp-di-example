using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Timers;

namespace Example.DI.Plugin;

public interface IExamplePlugin : IPlugin
{
    string ModuleAuthor { get; }

    string ModuleDescription { get; }

    string ModulePath { get; }

    string ModuleDirectory { get; }

    // Summary:
    //     Registers a game event handler.
    //
    // Parameters:
    //   handler:
    //     The event handler to register.
    //
    //   hookMode:
    //     The mode in which the event handler is hooked. Default is `HookMode.Post`.
    //
    // Type parameters:
    //   T:
    //     The type of the game event.
    void RegisterEventHandler<T>(BasePlugin.GameEventHandler<T> handler, HookMode hookMode = HookMode.Post) 
        where T : GameEvent;

    void DeregisterEventHandler(string name, Delegate handler, bool post);

    // Summary:
    //     Registers a new server command.
    //
    // Parameters:
    //   name:
    //     The name of the command.
    //
    //   description:
    //     The description of the command.
    //
    //   handler:
    //     The callback function to be invoked when the command is executed.
    void AddCommand(string name, string description, CommandInfo.CommandCallback handler);

    void AddCommandListener(string? name, CommandInfo.CommandListenerCallback handler, HookMode mode = HookMode.Pre);

    void RemoveCommand(string name, CommandInfo.CommandCallback handler);

    void RemoveCommandListener(string name, CommandInfo.CommandListenerCallback handler, HookMode mode);

    void RegisterListener<T>(T handler) 
        where T : Delegate;

    void RemoveListener(string name, Delegate handler);

    CounterStrikeSharp.API.Modules.Timers.Timer AddTimer(float interval, Action callback, TimerFlags? flags = null);

    void RegisterAllAttributes(object instance);

    void InitializeConfig(object instance, Type pluginType);

    // Summary:
    //     Registers all game event handlers that are decorated with the `[GameEventHandler]`
    //     attribute.
    //
    // Parameters:
    //   instance:
    //     The instance of the object where the event handlers are defined.
    void RegisterAttributeHandlers(object instance);

    void RegisterConsoleCommandAttributeHandlers(object instance);
}