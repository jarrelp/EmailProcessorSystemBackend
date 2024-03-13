namespace EmailFetchingService.Models;

//? kan naar meerdere ontvangers verstuurd worden
//? hoe werkt het met meedere email templates

public class EmailData
{
  // general email data
  public string Subject { get; set; } = "";
  public EmailType EmailType { get; set; } = EmailType.PaymentConfirmation;
  // public List<string> Attachments { get; set; }

  // sender & recipient
  public EmailSenderData Sender { get; set; } = new EmailSenderData();
  public EmailRecipientData Recipient { get; set; } = new EmailRecipientData();

  // email template data
  public AccountConfirmationData AccountConfirmationData { get; set; } = new AccountConfirmationData();
  public AppointmentReminderData AppointmentReminderData { get; set; } = new AppointmentReminderData();
  public PaymentConfirmationData PaymentConfirmationData { get; set; } = new PaymentConfirmationData();
  public NewsletterData NewsletterData { get; set; } = new NewsletterData();
  public ForgotPasswordData ForgotPasswordData { get; set; } = new ForgotPasswordData();
}