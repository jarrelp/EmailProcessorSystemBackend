namespace OracleSimulation;

public class EmailSimulation
{
    private readonly IPubSubService _pubSubService;
    private Random _rnd;
    private int _minEntryDelayInMS = 1000;
    private int _maxEntryDelayInMS = 3000;

    public EmailSimulation(IPubSubService emailFetchingService)
    {
        _rnd = new Random();
        _pubSubService = emailFetchingService;
    }

    public Task Start()
    {
        while (true)
        {
            try
            {
                // simulate entry
                TimeSpan entryDelay = TimeSpan.FromMilliseconds(_rnd.Next(_minEntryDelayInMS, _maxEntryDelayInMS) + _rnd.NextDouble());
                Task.Delay(entryDelay).Wait();

                Task.Run(async () =>
                {
                    // simulate entry
                    DateTime entryTimestamp = DateTime.Now;
                    var oracleData = new OracleData
                    {
                        Data = LicenseNumberGenerator.GetInstance().GenerateRandomLicenseNumber(),
                        Timestamp = entryTimestamp
                    };
                    await _pubSubService.SendDataAsync(oracleData);
                    Console.WriteLine($"Simulated Oracle email data with data {oracleData.Data}");
                }).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }
    }
}
