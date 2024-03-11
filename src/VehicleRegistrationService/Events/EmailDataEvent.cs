namespace VehicleRegistrationService.Events;

public record struct EmailDataEvent(Dictionary<string, string> Metadata, string Body);
