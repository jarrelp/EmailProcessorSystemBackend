namespace EmailFetchingService.Models;

public class OracleDataState
{
    public string Id { get; set; } = "";
    public EmailData Data { get; set; } = new EmailData();
    public DateTime Timestamp { get; set; } = new DateTime();
}
