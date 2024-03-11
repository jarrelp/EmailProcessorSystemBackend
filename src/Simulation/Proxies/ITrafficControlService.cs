namespace Simulation.Proxies;

public interface ITrafficControlService
{
    public Task SendVehicleEntryAsync(OracleData oracleData);
}
