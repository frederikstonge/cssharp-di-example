using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Logging;

public static class CSSharpLoggerExtensions
{
    public static ILoggingBuilder AddCSSharp(this ILoggingBuilder builder, ILogger logger)
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider>(new CSSharpLoggerProvider(logger)));
        return builder;
    }
}