namespace OracleSimulation.Helpers;

public class EmailTypeGenerator
{
  private Random _rnd;

  public EmailTypeGenerator()
  {
    _rnd = new Random();
  }

  public EmailType Generate()
  {
    EmailType[] emailTypes = (EmailType[])Enum.GetValues(typeof(EmailType));
    int index = _rnd.Next(emailTypes.Length);
    return emailTypes[index];
  }
}