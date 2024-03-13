namespace EmailFetchingService.Events;

public record struct OracleDataEvent(string Id, EmailData Data, DateTime Timestamp);