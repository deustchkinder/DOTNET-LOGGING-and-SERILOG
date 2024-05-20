using App.Service.AppServices;
using App.Repository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using App.Repository.Extensions;
using App.Repository.Exceptions;
using System.Diagnostics;
using App.Application.Extensions;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        hostContext.Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        hostContext.HostingEnvironment.EnvironmentName = "Development";

        Serilog.Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(hostContext.Configuration)
            .CreateLogger();

        services.AddSerilog();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();
            loggingBuilder.AddSerilog();
        });

        services.AddScoped<IUserxService, UserxService>();
        services.AddScoped<IUserxRepo, UserxRepo>();

        services.AddApplicationServices();
      
    });

var app = hostBuilder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

var stopWatch = Stopwatch.StartNew();

try
{
    logger.LogInformation("{@msg}", $"REQUEST START: {DateTime.Now}");
    var scope = app.Services.CreateScope();
    var provider = scope.ServiceProvider;
    var userxService = provider.GetRequiredService<IUserxService>();
    var userx = userxService.GetUserx();
    Console.WriteLine(userx);
    var elapsed = stopWatch.ElapsedMilliseconds;
    stopWatch.Stop();
    logger.LogInformation("{@msg} {@Duration}", $"REQUEST END: {DateTime.Now}", $"{elapsed} ms");
    await app.RunAsync();
}
catch (RepositoryExceptions ex)
{
    logger.LogError(ex, ex.Message);
    Console.WriteLine(ex.Message);
}
catch (ApplicationException ex)
{
    logger.LogError(ex, ex.Message);
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    logger.LogError(ex, ex.Message);
    Console.WriteLine("SUNUCU HATASI 500");
}
finally
{
    Serilog.Log.CloseAndFlush();
}

Console.Read();