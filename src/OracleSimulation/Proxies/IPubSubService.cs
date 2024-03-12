namespace OracleSimulation.Proxies;

public interface IPubSubService
{
    public Task SendDataAsync(OracleData oracleData);
}
