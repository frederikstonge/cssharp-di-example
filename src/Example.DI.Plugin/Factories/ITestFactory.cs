using Example.DI.Plugin.Services;

namespace Example.DI.Plugin.Factories;

public interface ITestFactory
{
    ITestService Create(string name);
}