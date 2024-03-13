namespace EmailFetchingService.Models.EmailTemplateData;

public class AppointmentReminderData
{
    public DateTime? AppointmentDateTime { get; set; }
    public string? Location { get; set; }
    public string? Instructions { get; set; }
}
