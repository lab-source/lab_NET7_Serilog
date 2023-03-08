using lab_NET7_Serilog.Helper;
using lab_NET7_Serilog.logger;

namespace lab_NET7_Serilog.Service;

public class TestService : ITestService
{
    private readonly IMyLogger _myLogger;
    private readonly HttpClient _httpClient;

    public TestService(IMyLogger logger, HttpClient? httpClient = null)
    {
        _myLogger = logger;
        _httpClient = httpClient ?? HttpClientFactory.CreateHttpClient(_myLogger);
    }

    public async Task<string> Search(string searchKey)
    {
        var response = await _httpClient.GetAsync(new Uri("https://github.com/")) .ConfigureAwait(false);

        return await response.Content.ReadAsStringAsync();
    }
}