namespace OracleSimulation.Proxies;

public class PubSubService : IPubSubService
{
    private readonly DaprClient _daprClient;

    public PubSubService(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task SendDataAsync(OracleData oracleData)
    {
        await _daprClient.PublishEventAsync("pubsub", "oracledata", oracleData);
    }
}
