namespace lab_NET7_Serilog.logger;

public class HttpDelegatingHandler : DelegatingHandler
{
    private IMyLogger _logger;

    public HttpDelegatingHandler(IMyLogger logger) : this(logger, new HttpClientHandler())
    {
        _logger = logger;
    }

    internal HttpDelegatingHandler(IMyLogger logger, HttpMessageHandler handler) : base(handler)
        => _logger = logger;


    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            await _logger.CallApi(request.RequestUri, request.Content).ConfigureAwait(false);
        }
    }
}