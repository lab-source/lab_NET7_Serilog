namespace lab_NET7_Serilog.logger;

public class MyLogger : IMyLogger
{
    private readonly ILogger<MyLogger> _logger;

    public MyLogger(ILogger<MyLogger> logger)
    {
        _logger = logger;
    }
    
    public Task CallApi(Uri uri, HttpContent httpContent)
    {
        _logger.LogWarning($"From My Logger uri: {uri}, Content: {httpContent}");
        return Task.CompletedTask;
    }

    public Task ReceivedEvents(byte[] eventData)
    {
        _logger.LogWarning($"From My Logger {eventData}");
        return Task.CompletedTask;
    }

    public Task ForTest(string log)
    {
        _logger.LogWarning(log);
        return Task.CompletedTask;
    }
}