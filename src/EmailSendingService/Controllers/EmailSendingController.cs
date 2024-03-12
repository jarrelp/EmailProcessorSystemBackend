using System.Text.Json;

namespace EmailSendingService.Controllers;

[ApiController]
[Route("")]
public class EmailSendingController : ControllerBase
{
    private readonly ILogger<EmailSendingController> _logger;

    public EmailSendingController(ILogger<EmailSendingController> logger)
    {
        _logger = logger;
    }

    [Topic("pubsub", "emaildata", "deadletters", false)]
    [Route("getEmailData")]
    [HttpPost()]
    public async Task<ActionResult> GetEmailData(EmailDataEvent @event, [FromServices] DaprClient daprClient)
    {
        // log e-mail
        _logger.LogInformation($"Email data: {@event.ToString()}");

        // publish data (Dapr publish / subscribe)
        await daprClient.InvokeBindingAsync("sendmail", "create", @event.Body, @event.Metadata);

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
