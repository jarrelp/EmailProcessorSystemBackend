namespace OracleSimulation.Helpers;

public class LinkGenerator
{
  private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
  private readonly string[] ValidExtensions = { ".nl", ".com", ".hotmail", ".org", ".net", ".yahoo", ".live", ".outlook" };

  private Random _rnd;

  public LinkGenerator()
  {
    _rnd = new Random();
  }

  public string Generate()
  {
    int length = _rnd.Next(10, 20);
    int extensionIndex = _rnd.Next(ValidExtensions.Length);
    string extension = ValidExtensions[extensionIndex];

    char[] link = new char[length];
    for (int i = 0; i < length - extension.Length - 1; i++)
    {
      link[i] = Characters[_rnd.Next(Characters.Length)];
    }

    link[length - extension.Length - 1] = '/';

    for (int i = length - extension.Length; i < length; i++)
    {
      link[i] = extension[i - (length - extension.Length)];
    }

    return "https://" + new string(link);
  }
}