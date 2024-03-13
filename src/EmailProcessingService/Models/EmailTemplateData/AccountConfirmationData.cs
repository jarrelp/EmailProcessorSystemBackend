namespace EmailProcessingService.Models.EmailTemplateData;

public class AccountConfirmationData
{
    public DateTime? RegistrationDate { get; set; }
    public string? ActivationLink { get; set; }
}