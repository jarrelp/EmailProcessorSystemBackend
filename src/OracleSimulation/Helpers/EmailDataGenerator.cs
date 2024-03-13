namespace OracleSimulation.Helpers;

public class EmailDataGenerator
{
  private EmailTypeGenerator _emailTypeGenerator = new EmailTypeGenerator();
  private EmailGenerator _emailGenerator = new EmailGenerator();
  private DateGenerator _dateGenerator = new DateGenerator();
  private FotoGenerator _fotoGenerator = new FotoGenerator();
  private LinkGenerator _linkGenerator = new LinkGenerator();
  private NameGenerator _nameGenerator = new NameGenerator();
  private LocationGenerator _locationGenerator = new LocationGenerator();

  private EmailData _emailData = new EmailData();

  public EmailDataGenerator() { }

  public EmailData Generate()
  {
    // generate general email data
    var emailType = _emailTypeGenerator.Generate();
    _emailData.Subject = emailType.ToString();
    _emailData.EmailType = emailType;
    _emailData.Sender = generateSender();
    _emailData.Recipient = generateRecipient();

    // generate email template data
    switch (emailType)
    {
      case EmailType.AccountConfirmation:
        _emailData.AccountConfirmationData = generateAccountConfirmation();
        break;
      case EmailType.AppointmentReminder:
        _emailData.AppointmentReminderData = generateAppointmentReminder();
        break;
      case EmailType.PaymentConfirmation:
        _emailData.PaymentConfirmationData = generatePaymentConfirmation();
        break;
      case EmailType.ForgotPassword:
        _emailData.ForgotPasswordData = generateForgotPassword();
        break;
      case EmailType.Newsletter:
        _emailData.NewsletterData = generateNewsletter();
        break;
      default:
        throw new InvalidOperationException("Onbekend e-mailtype: " + emailType);
    }

    return _emailData;
  }

  private EmailSenderData generateSender()
  {
    var sender = new EmailSenderData
    {
      FirstName = _nameGenerator.GenerateFirstName(),
      SurName = _nameGenerator.GenerateSurName(),
      EmailAddress = _emailGenerator.Generate()
    };
    return sender;
  }

  private EmailRecipientData generateRecipient()
  {
    var sender = new EmailRecipientData
    {
      FirstName = _nameGenerator.GenerateFirstName(),
      SurName = _nameGenerator.GenerateSurName(),
      EmailAddress = _emailGenerator.Generate()
    };
    return sender;
  }

  private AccountConfirmationData generateAccountConfirmation()
  {
    var accountConfirmationData = new AccountConfirmationData
    {
      RegistrationDate = _dateGenerator.Generate(),
      ActivationLink = _nameGenerator.GenerateSurName()
    };
    return accountConfirmationData;
  }

  private AppointmentReminderData generateAppointmentReminder()
  {
    var appointmentReminderData = new AppointmentReminderData
    {
      AppointmentDateTime = _dateGenerator.Generate(),
      Location = _locationGenerator.Generate(),
      Instructions = "Ga naar het Adres. U kunt ons kantoor bereiken met de auto, het openbaar vervoer of te voet, afhankelijk van uw voorkeur en locatie. Zodra u bij ons kantoor aankomt, vindt u onze ingang aan de zijkant. Onze receptie bevindt zich bij de ingang, waar ons team u zal verwelkomen. Als u met de auto komt, hebben we parkeergelegenheid beschikbaar aan de parkeerplaats voor uw gemak. Zorg ervoor dat u op tijd arriveert om voldoende parkeergelegenheid te vinden."
    };
    return appointmentReminderData;
  }

  private PaymentConfirmationData generatePaymentConfirmation()
  {
    var paymentConfirmationData = new PaymentConfirmationData
    {
      OrderNumber = Guid.NewGuid().ToString(),
      CustomerName = _nameGenerator.GenerateFirstName() + " " + _nameGenerator.GenerateSurName(),
      PaymentDate = _dateGenerator.Generate(),
      Amount = 5,
      PaymentMethod = "IDeal",
      PaymentStatus = "Payed",
      ReferenceNumber = Guid.NewGuid().ToString(),
      Description = "Geachte klant, wij willen u hartelijk bedanken voor uw recente aankoop bij onze winkel. Uw betaling is succesvol ontvangen en uw bestelling is nu in behandeling. Binnenkort kunt u uw gekochte items verwachten. Als u nog vragen heeft over uw bestelling, aarzel dan niet om contact met ons op te nemen. Nogmaals bedankt voor uw vertrouwen in ons bedrijf."
    };
    return paymentConfirmationData;
  }

  private ForgotPasswordData generateForgotPassword()
  {
    var forgotPasswordData = new ForgotPasswordData
    {
      ResetInstructions = "Beste gebruiker, we hebben gemerkt dat u uw wachtwoord bent vergeten voor uw account bij onze service. Geen zorgen, we zijn hier om te helpen! Klik op de link hieronder om uw wachtwoord opnieuw in te stellen. Volg de instructies op het scherm en u krijgt binnen enkele ogenblikken toegang tot uw account. Als u deze wachtwoordreset niet heeft aangevraagd, kunt u deze e-mail veilig negeren. Bedankt voor uw begrip en onze excuses voor het eventuele ongemak."
    };
    return forgotPasswordData;
  }

  private NewsletterData generateNewsletter()
  {
    var newsletterData = new NewsletterData
    {
      Content = "Beste lezer, we zijn verheugd om u onze nieuwste nieuwsbrief te presenteren! In deze editie hebben we spannende updates, interessante artikelen en exclusieve aanbiedingen die u niet mag missen. Ontdek de laatste trends, tips en nieuws binnen ons vakgebied. Blijf op de hoogte van alles wat er speelt en profiteer van speciale kortingen voor abonnees. Klik op de onderstaande link om de nieuwsbrief te lezen en mis het niet! Veel leesplezier en bedankt voor uw interesse in ons nieuws.",
      Image = _fotoGenerator.Generate(),
      Link = _linkGenerator.Generate()
    };
    return newsletterData;
  }
}