public class NameGenerator
{
  private List<string> _firstNames;
  private List<string> _surNames;
  private Random _rnd;

  public NameGenerator()
  {
    _rnd = new Random();
    InitializeFirstNames();
    InitializeSurNames();
  }

  public string GenerateFirstName()
  {
    return _firstNames[_rnd.Next(0, _firstNames.Count)];
  }

  public string GenerateSurName()
  {
    return _surNames[_rnd.Next(0, _surNames.Count)];
  }

  private void InitializeFirstNames()
  {
    _firstNames = new List<string>
            {
                "John", "Emma", "Michael", "Olivia", "William",
                "Sophia", "James", "Ava", "Alexander", "Isabella",
                "Daniel", "Mia", "Matthew", "Charlotte", "Elijah",
                "Amelia", "David", "Harper", "Joseph", "Evelyn",
                "Benjamin", "Abigail", "Samuel", "Emily", "Christopher",
                "Elizabeth", "Luke", "Mila", "Henry", "Ella",
                "Andrew", "Avery", "Joshua", "Scarlett", "Gabriel",
                "Sofia", "Jackson", "Chloe", "Anthony", "Grace",
                "Ethan", "Liam", "Madison", "Victoria", "Mason",
                "Natalie", "Logan", "Luna"
            };
  }

  private void InitializeSurNames()
  {
    _surNames = new List<string>
            {
                "Smith", "Johnson", "Williams", "Brown", "Jones",
                "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson",
                "Thomas", "Taylor", "Moore", "Jackson", "Martin",
                "Lee", "Perez", "Thompson", "White", "Harris",
                "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
                "Walker", "Young", "Allen", "King", "Wright",
                "Scott", "Torres", "Nguyen", "Hill", "Flores",
                "Green", "Adams", "Nelson", "Baker", "Hall",
                "Rivera", "Campbell", "Mitchell", "Carter"
            };
  }
}