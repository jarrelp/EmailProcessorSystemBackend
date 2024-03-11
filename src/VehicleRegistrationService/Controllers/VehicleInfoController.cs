using System.Text.Json;

namespace VehicleRegistrationService.Controllers;

[ApiController]
[Route("")]
public class VehicleInfoController : ControllerBase
{
    private readonly ILogger<VehicleInfoController> _logger;

    public VehicleInfoController(ILogger<VehicleInfoController> logger)
    {
        _logger = logger;
    }

    [Topic("pubsub", "emaildata", "deadletters", false)]
    [Route("collectfine")]
    [HttpPost()]
    public async Task<ActionResult> CollectFine(EmailDataEvent @event, [FromServices] DaprClient daprClient)
    {
        // log e-mail
        _logger.LogInformation($"Email data: {@event.ToString()}");

        // publish speedingviolation (Dapr publish / subscribe)
        await daprClient.InvokeBindingAsync("sendmail", "create", @event.Body, @event.Metadata);

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
