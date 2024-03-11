namespace EmailFetchingService.Models;

public record struct OracleDataState
{
    public string Data { get; init; }
    public DateTime EntryTimestamp { get; init; }

    public OracleDataState(string data, DateTime entryTimestamp)
    {
        this.Data = data;
        this.EntryTimestamp = entryTimestamp;
    }
}
