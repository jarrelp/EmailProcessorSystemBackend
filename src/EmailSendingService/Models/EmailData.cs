namespace EmailSendingService.Models;

public record struct EmailData(Dictionary<string, string> Metadata, string Body);
