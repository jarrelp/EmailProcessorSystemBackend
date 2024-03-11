namespace TrafficControlService.Controllers;

[ApiController]
[Route("")]
public class TrafficController : ControllerBase
{
    private readonly ILogger<TrafficController> _logger;
    private readonly IVehicleStateRepository _vehicleStateRepository;

    public TrafficController(
        ILogger<TrafficController> logger,
        IVehicleStateRepository vehicleStateRepository)
    {
        _logger = logger;
        _vehicleStateRepository = vehicleStateRepository;
    }

    [Topic("pubsub", "oracledata", "deadletters", false)]
    [Route("collectfine")]
    [HttpPost()]
    public async Task<ActionResult> CollectFine(OracleDataEvent @event, [FromServices] DaprClient daprClient)
    {
        try
        {
            // log entry
            _logger.LogInformation($"Oracle data fetched at {@event.Timestamp.ToString("hh:mm:ss")} " +
                $"with the following data {@event.Data}.");

            // store vehicle state
            var vehicleState = new OracleDataState(@event.Data, @event.Timestamp);
            await _vehicleStateRepository.SaveVehicleStateAsync(vehicleState);

            // get vehicle state
            var state = await _vehicleStateRepository.GetVehicleStateAsync(@event.Data);
            if (state == default(OracleDataState))
            {
                return NotFound();
            }

            // handle possible speeding violation
            _logger.LogInformation($"Statestore data: " +
                $"{state.Value.Data}.");

            // publish speedingviolation (Dapr publish / subscribe)
            await daprClient.PublishEventAsync("pubsub", "fetchedData", @event);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing ENTRY");
            return StatusCode(500);
        }
    }
}
