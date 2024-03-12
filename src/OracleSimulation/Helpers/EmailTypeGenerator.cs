// Wachtwoord vergeten
// Accountregistratie
// Bestellingsbevestiging
// Accountbevestigingse-mail
// Verzendingstracking
// Nieuwsbrief
// Gebruikersfeedback
// Herrinnering aan verlaten winkelwagentje
// Wachtwoord-reset-e-mail
// verzendingsmelding
// Afspraakherinnering

namespace OracleSimulation.Helpers;

public class EmailTypeGenerator
{
  private static EmailTypeGenerator _instance;
  private List<string> _emailTypes;
  private Random _rnd;

  private EmailTypeGenerator()
  {
    _rnd = new Random();
    InitializeEmailTypes();
  }

  public static EmailTypeGenerator GetInstance()
  {
    if (_instance == null)
    {
      _instance = new EmailTypeGenerator();
    }
    return _instance;
  }

  public string GetRandomEmailType()
  {
    return _emailTypes[_rnd.Next(0, _emailTypes.Count)];
  }

  private void InitializeEmailTypes()
  {
    _emailTypes = new List<string>
        {
            "Accountbevestiging",
            "Wachtwoord vergeten",
            "Nieuwsbrief",
            "Aankoopbevestiging",
            "Beoordelingsverzoek",
            "Afspraakherinnering"
        };
  }
}