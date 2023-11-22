using Microsoft.Extensions.Logging;

namespace Example.DI.Plugin.Services;

public class TestService : ITestService
{
    private readonly ILogger _logger;
    private readonly string _name;

    public TestService(ILogger<TestService> logger, string name)
    {
        _logger = logger;
        _name = name;
    }
}