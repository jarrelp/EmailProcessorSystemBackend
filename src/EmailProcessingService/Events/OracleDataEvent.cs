namespace EmailProcessingService.Events;

public record struct OracleDataEvent(string Data, DateTime Timestamp);
