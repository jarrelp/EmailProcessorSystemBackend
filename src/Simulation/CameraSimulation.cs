namespace Simulation;

public class CameraSimulation
{
    private readonly MqttTrafficControlService _trafficControlService;
    private Random _rnd;
    private int _minEntryDelayInMS = 1000;
    private int _maxEntryDelayInMS = 3000;

    public CameraSimulation(MqttTrafficControlService trafficControlService)
    {
        _rnd = new Random();
        _trafficControlService = trafficControlService;
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
                        Data = GenerateRandomLicenseNumber(),
                        Timestamp = entryTimestamp
                    };
                    await _trafficControlService.SendVehicleEntryAsync(oracleData);
                    Console.WriteLine($"Simulated ENTRY of vehicle with license-number {oracleData.Data}");
                }).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }
    }

    #region Private helper methods

    private string _validLicenseNumberChars = "DFGHJKLNPRSTXYZ";

    private string GenerateRandomLicenseNumber()
    {
        int type = _rnd.Next(1, 9);
        string kenteken = string.Empty;
        switch (type)
        {
            case 1: // 99-AA-99
                kenteken = string.Format("{0:00}-{1}-{2:00}", _rnd.Next(1, 99), GenerateRandomCharacters(2), _rnd.Next(1, 99));
                break;
            case 2: // AA-99-AA
                kenteken = string.Format("{0}-{1:00}-{2}", GenerateRandomCharacters(2), _rnd.Next(1, 99), GenerateRandomCharacters(2));
                break;
            case 3: // AA-AA-99
                kenteken = string.Format("{0}-{1}-{2:00}", GenerateRandomCharacters(2), GenerateRandomCharacters(2), _rnd.Next(1, 99));
                break;
            case 4: // 99-AA-AA
                kenteken = string.Format("{0:00}-{1}-{2}", _rnd.Next(1, 99), GenerateRandomCharacters(2), GenerateRandomCharacters(2));
                break;
            case 5: // 99-AAA-9
                kenteken = string.Format("{0:00}-{1}-{2}", _rnd.Next(1, 99), GenerateRandomCharacters(3), _rnd.Next(1, 10));
                break;
            case 6: // 9-AAA-99
                kenteken = string.Format("{0}-{1}-{2:00}", _rnd.Next(1, 9), GenerateRandomCharacters(3), _rnd.Next(1, 10));
                break;
            case 7: // AA-999-A
                kenteken = string.Format("{0}-{1:000}-{2}", GenerateRandomCharacters(2), _rnd.Next(1, 999), GenerateRandomCharacters(1));
                break;
            case 8: // A-999-AA
                kenteken = string.Format("{0}-{1:000}-{2}", GenerateRandomCharacters(1), _rnd.Next(1, 999), GenerateRandomCharacters(2));
                break;
        }

        return kenteken;
    }

    private string GenerateRandomCharacters(int aantal)
    {
        char[] chars = new char[aantal];
        for (int i = 0; i < aantal; i++)
        {
            chars[i] = _validLicenseNumberChars[_rnd.Next(_validLicenseNumberChars.Length - 1)];
        }
        return new string(chars);
    }

    #endregion
}
