namespace OracleSimulation.Helpers;

public class LocationGenerator
{
  private readonly string[] _cityNames = {
        "Amsterdam", "Rotterdam", "Utrecht", "Den Haag", "Eindhoven",
        "Groningen", "Maastricht", "Nijmegen", "Haarlem", "Leeuwarden",
        "Zwolle", "Breda", "Enschede", "Arnhem", "Tilburg", "Leiden"
    };
  private Random _rnd;

  public LocationGenerator()
  {
    _rnd = new Random();
  }

  public string Generate()
  {
    int index = _rnd.Next(0, _cityNames.Length);
    return _cityNames[index];
  }
}