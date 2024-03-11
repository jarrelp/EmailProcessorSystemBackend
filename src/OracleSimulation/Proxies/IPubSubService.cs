namespace OracleSimulation.Proxies;

public interface IPubSubService
{
    public Task SendVehicleEntryAsync(OracleData oracleData);
}
