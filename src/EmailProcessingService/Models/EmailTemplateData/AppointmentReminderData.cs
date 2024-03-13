namespace EmailProcessingService.Models.EmailTemplateData;

public class AppointmentReminderData
{
    public DateTime AppointmentDateTime { get; set; } = new DateTime();
    public string Location { get; set; } = "";
    public string Instructions { get; set; } = "";
}
