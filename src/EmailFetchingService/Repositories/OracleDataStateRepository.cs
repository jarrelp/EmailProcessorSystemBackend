namespace EmailFetchingService.Repositories;

public class OracleDataStateRepository : IOracleDataStateRepository
{
    private const string DAPR_STORE_NAME = "statestore";
    private readonly DaprClient _daprClient;

    public OracleDataStateRepository(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task SaveOracleDataStateAsync(OracleDataState state)
    {
        await _daprClient.SaveStateAsync<OracleDataState>(
            DAPR_STORE_NAME, state.Data, state);
    }

    public async Task<OracleDataState?> GetOracleDataStateAsync(string data)
    {
        var stateEntry = await _daprClient.GetStateEntryAsync<OracleDataState>(
            DAPR_STORE_NAME, data);
        return stateEntry.Value;
    }
}
