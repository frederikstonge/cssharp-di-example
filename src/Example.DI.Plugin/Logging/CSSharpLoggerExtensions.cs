using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Logging;

public static class CSSharpLoggerExtensions
{
    public static ILoggingBuilder AddCSSharp(this ILoggingBuilder builder)
    {
        var descriptor = new ServiceDescriptor(typeof(ILoggerFactory), CounterStrikeSharp.API.Core.Logging.CoreLogging.Factory);
        builder.Services.Replace(descriptor);
        return builder;
    }
}