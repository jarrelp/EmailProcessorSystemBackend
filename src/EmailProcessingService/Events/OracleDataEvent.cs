namespace EmailProcessingService.Events;

public record struct OracleDataEvent(string Id, EmailData Data, DateTime Timestamp);
