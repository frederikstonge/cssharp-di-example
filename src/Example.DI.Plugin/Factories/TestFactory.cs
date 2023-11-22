using Example.DI.Plugin.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Factories;

public class TestFactory : ITestFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TestFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITestService Create(string name)
    {
        return new TestService(_serviceProvider.GetRequiredService<ILogger<TestService>>(), name);
    }
}