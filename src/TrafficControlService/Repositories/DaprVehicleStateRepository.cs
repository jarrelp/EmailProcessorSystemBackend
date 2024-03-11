namespace TrafficControlService.Repositories;

public class DaprVehicleStateRepository : IVehicleStateRepository
{
    private const string DAPR_STORE_NAME = "statestore";
    private readonly DaprClient _daprClient;

    public DaprVehicleStateRepository(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task SaveVehicleStateAsync(OracleDataState state)
    {
        await _daprClient.SaveStateAsync<OracleDataState>(
            DAPR_STORE_NAME, state.Data, state);
    }

    public async Task<OracleDataState?> GetVehicleStateAsync(string data)
    {
        var stateEntry = await _daprClient.GetStateEntryAsync<OracleDataState>(
            DAPR_STORE_NAME, data);
        return stateEntry.Value;
    }
}
