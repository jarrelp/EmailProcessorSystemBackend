namespace TrafficControlService.Repositories;

public interface IVehicleStateRepository
{
    Task SaveVehicleStateAsync(OracleDataState state);
    Task<OracleDataState?> GetVehicleStateAsync(string data);
}
