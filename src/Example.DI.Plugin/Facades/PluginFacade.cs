namespace Example.DI.Plugin.Facades;

public class PluginFacade : IPluginFacade
{
    private readonly HttpClient _httpClient;

    public PluginFacade(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}