namespace OracleSimulation.Models.EmailTemplateData;

public class AccountConfirmationData
{
    public DateTime RegistrationDate { get; set; } = new DateTime();
    public string ActivationLink { get; set; } = "";
}