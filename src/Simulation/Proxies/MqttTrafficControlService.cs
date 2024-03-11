namespace Simulation.Proxies;

public class MqttTrafficControlService : ITrafficControlService
{
    private readonly DaprClient _daprClient;

    public MqttTrafficControlService(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task SendVehicleEntryAsync(OracleData oracleData)
    {
        await _daprClient.PublishEventAsync("pubsub", "oracledata", oracleData);
    }
}
