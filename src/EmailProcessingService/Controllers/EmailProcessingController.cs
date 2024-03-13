using System.Text.Json;

namespace EmailProcessingService.Controllers;

[ApiController]
[Route("")]
public class EmailProcessingController : ControllerBase
{
    private readonly ILogger<EmailProcessingController> _logger;

    public EmailProcessingController(ILogger<EmailProcessingController> logger)
    {
        _logger = logger;
    }

    [Topic("pubsub", "fetchedData", "deadletters", false)]
    [Route("getfetcheddata")]
    [HttpPost()]
    public async Task<ActionResult> GetFetchedData(OracleDataEvent @event, [FromServices] DaprClient daprClient)
    {
        // log e-mail
        _logger.LogInformation($"Id: {@event.Id} " +
            $"On: {@event.Timestamp.ToString("dd-MM-yyyy")} " +
            $"at {@event.Timestamp.ToString("hh:mm:ss")}.");

        // process email (Dapr output binding)
        var emailType = @event.Data.EmailType;

        string? body;
        switch (emailType)
        {
            case EmailType.AccountConfirmation:
                body = AccountConfirmation.CreateEmailBody(@event);
                break;
            case EmailType.AppointmentReminder:
                body = AppointmentReminder.CreateEmailBody(@event);
                break;
            case EmailType.PaymentConfirmation:
                body = PaymentConfirmation.CreateEmailBody(@event);
                break;
            case EmailType.ForgotPassword:
                body = ForgotPassword.CreateEmailBody(@event);
                break;
            case EmailType.Newsletter:
                body = Newsletter.CreateEmailBody(@event);
                break;
            default:
                throw new InvalidOperationException("Onbekend e-mailtype: " + emailType);
        }

        var metadata = new Dictionary<string, string>
        {
            ["emailFrom"] = @event.Data.Sender.EmailAddress,
            ["emailTo"] = @event.Data.Recipient.EmailAddress,
            ["subject"] = @event.Data.Subject
        };

        var emailData = new EmailDataEvent(metadata, body);

        // publish data (Dapr publish / subscribe)
        await daprClient.PublishEventAsync("pubsub", "emaildata", emailData);

        return Ok();
    }

    [Topic("pubsub", "deadletters")]
    [Route("deadletters")]
    [HttpPost()]
    public ActionResult HandleDeadLetter(object message)
    {
        _logger.LogError("The service was not able to handle the message.");

        try
        {
            var messageJson = JsonSerializer.Serialize<object>(message);
            _logger.LogInformation($"Unhandled message content: {messageJson}");
        }
        catch
        {
            _logger.LogError("Unhandled message's payload could not be deserialized.");
        }

        return Ok();
    }
}
