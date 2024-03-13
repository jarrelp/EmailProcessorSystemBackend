namespace OracleSimulation.Helpers;

public class DateGenerator
{
  private Random _rnd;

  public DateGenerator()
  {
    _rnd = new Random();
  }

  public DateTime Generate()
  {
    DateTime now = DateTime.Now;
    int minutesToAdd = _rnd.Next(-10, 11);
    return now.AddMinutes(minutesToAdd);
  }
}