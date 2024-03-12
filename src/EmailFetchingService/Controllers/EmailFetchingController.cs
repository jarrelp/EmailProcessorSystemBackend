namespace EmailFetchingService.Controllers;

[ApiController]
[Route("")]
public class EmailFetchingController : ControllerBase
{
    private readonly ILogger<EmailFetchingController> _logger;
    private readonly IOracleDataStateRepository _oracleDataStateRepository;

    public EmailFetchingController(
        ILogger<EmailFetchingController> logger,
        IOracleDataStateRepository oracleDataStateRepository)
    {
        _logger = logger;
        _oracleDataStateRepository = oracleDataStateRepository;
    }

    [Topic("pubsub", "oracledata", "deadletters", false)]
    [Route("getoracledata")]
    [HttpPost()]
    public async Task<ActionResult> GetOracleData(OracleDataEvent @event, [FromServices] DaprClient daprClient)
    {
        try
        {
            // log entry
            _logger.LogInformation($"Oracle data fetched at {@event.Timestamp.ToString("hh:mm:ss")} " +
                $"with the following data {@event.Data}.");

            // store oracle data state
            var oracleDataState = new OracleDataState(@event.Data, @event.Timestamp);
            await _oracleDataStateRepository.SaveOracleDataStateAsync(oracleDataState);

            // get oracle data state
            var state = await _oracleDataStateRepository.GetOracleDataStateAsync(@event.Data);
            if (state == default(OracleDataState))
            {
                return NotFound();
            }

            // log
            _logger.LogInformation($"Statestore data: " +
                $"{state.Value.Data}.");

            // publish data (Dapr publish / subscribe)
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
