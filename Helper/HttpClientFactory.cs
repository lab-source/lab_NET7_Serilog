using lab_NET7_Serilog.logger;

namespace lab_NET7_Serilog.Helper;

public class HttpClientFactory
{
    public static HttpClient CreateHttpClient(IMyLogger logger)
    {
        var handler = new HttpDelegatingHandler(logger);
        var client = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://www.google.com.tw")
        };
        return client;
    }
}