namespace OracleSimulation.Helpers;

public class FotoGenerator
{
  private Random _rnd;

  public FotoGenerator()
  {
    _rnd = new Random();
  }

  public string Generate()
  {
    int photoId = _rnd.Next(1, 1001);
    return $"https://source.unsplash.com/random/800x600?sig={photoId}";
  }
}