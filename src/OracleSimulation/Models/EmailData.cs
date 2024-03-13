namespace OracleSimulation.Models;

//? kan naar meerdere ontvangers verstuurd worden
//? hoe werkt het met meedere email templates

public class EmailData
{
  // general email data
  public string Subject { get; set; }
  public EmailType EmailType { get; set; }
  // public List<string> Attachments { get; set; }

  // sender & recipient
  public EmailSenderData Sender { get; set; }
  public EmailRecipientData Recipient { get; set; }

  // email template data
  public AccountConfirmationData? AccountConfirmationData { get; set; }
  public AppointmentReminderData? AppointmentReminderData { get; set; }
  public PaymentConfirmationData? PaymentConfirmationData { get; set; }
  public NewsletterData? NewsletterData { get; set; }
  public ForgotPasswordData? ForgotPasswordData { get; set; }
}