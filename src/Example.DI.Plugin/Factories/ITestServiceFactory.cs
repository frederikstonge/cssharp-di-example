using Example.DI.Plugin.Services;

namespace Example.DI.Plugin.Factories;

public interface ITestServiceFactory
{
    ITestService Create(string name);
}