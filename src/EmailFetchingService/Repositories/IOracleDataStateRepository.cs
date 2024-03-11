namespace EmailFetchingService.Repositories;

public interface IOracleDataStateRepository
{
    Task SaveOracleDataStateAsync(OracleDataState state);
    Task<OracleDataState?> GetOracleDataStateAsync(string data);
}
