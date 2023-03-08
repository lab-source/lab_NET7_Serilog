using System.Diagnostics;
using lab_NET7_Serilog.logger;
using Microsoft.AspNetCore.Mvc;
using lab_NET7_Serilog.Models;
using lab_NET7_Serilog.Service;

namespace lab_NET7_Serilog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITestService _testService;
    private readonly IMyLogger _myLogger;
    public HomeController(ILogger<HomeController> logger, ITestService service,IMyLogger mylog)
    {
        _logger = logger;
        _testService = service;
        _myLogger = mylog;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("From HomeController Index");
        await _myLogger.ForTest("For Test Only");
        var result = await _testService.Search("test");
        
        return Ok(result);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
