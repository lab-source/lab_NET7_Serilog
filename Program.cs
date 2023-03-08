using lab_NET7_Serilog.logger;
using lab_NET7_Serilog.Service;
using Serilog;
using Serilog.Events;

try
{
    // 方式1
    // Log.Logger = new LoggerConfiguration()
    //     .MinimumLevel.Information()
    //     .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    //     .Enrich.FromLogContext()
    //     .WriteTo.Console()
    //     .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    //     .CreateLogger();

    // 方式2
    var builder = WebApplication.CreateBuilder(args);
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

    builder.Services.AddControllersWithViews();

    builder.Services.AddSingleton<IMyLogger, MyLogger>();
    builder.Services.AddSingleton<ITestService, TestService>();
    
    // 必要加入
    builder.Host.UseSerilog();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandled Exception");
}
finally
{
    Log.CloseAndFlush();
    Log.Information("結束服務");
}