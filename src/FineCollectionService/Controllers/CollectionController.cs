using System.Text.Json;

namespace FineCollectionService.Controllers;

[ApiController]
[Route("")]
public class CollectionController : ControllerBase
{
    private readonly ILogger<CollectionController> _logger;

    public CollectionController(ILogger<CollectionController> logger)
    {
        _logger = logger;
    }

    [Topic("pubsub", "fetchedData", "deadletters", false)]
    [Route("collectfine")]
    [HttpPost()]
    public async Task<ActionResult> CollectFine(OracleDataEvent @event, [FromServices] DaprClient daprClient)
    {
        // log e-mail
        _logger.LogInformation($"Vehicle: {@event.Data} " +
            $"On: {@event.Timestamp.ToString("dd-MM-yyyy")} " +
            $"at {@event.Timestamp.ToString("hh:mm:ss")}.");


        // send fine by email (Dapr output binding)
        var body = EmailUtils.CreateEmailBody(@event);
        var metadata = new Dictionary<string, string>
        {
            ["emailFrom"] = "noreply@cfca.gov",
            ["emailTo"] = "iemand@gmail.com",
            ["subject"] = $"Speeding violation"
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
        _logger.LogError("The service was not able to handle a CollectFine message.");

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
