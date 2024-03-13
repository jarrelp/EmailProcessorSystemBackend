namespace OracleSimulation.Helpers;

public class EmailGenerator
{
  private string[] _providers = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "example.com" };
  private string[] _emailPrefixes = {
            "cool", "super", "mega", "awesome", "epic", "fantastic", "amazing", "master", "pro", "ultra",
            "legendary", "golden", "elite", "ultimate", "power", "ninja", "champion", "star", "alpha", "omega",
            "dragon", "wizard", "hero", "king", "queen", "savage", "epic", "legend", "supreme",
            "fantasy", "mystery", "magic", "divine", "glory", "brave", "fierce", "victory", "honor",
            "dream", "infinity", "eternal", "cosmic", "universe", "infinity", "galaxy", "cosmos", "beyond",
            "solar", "moon", "sun"
  };
  private Random _rnd;

  public EmailGenerator()
  {
    _rnd = new Random();
  }

  public string Generate()
  {
    string prefix = _emailPrefixes[_rnd.Next(0, _emailPrefixes.Length)];

    string username = prefix + _rnd.Next(1000, 9999);

    string provider = _providers[_rnd.Next(0, _providers.Length)];

    string email = $"{username}@{provider}";

    return email;
  }
}