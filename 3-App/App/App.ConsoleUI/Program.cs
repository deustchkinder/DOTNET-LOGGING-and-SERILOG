using App.ConsoleUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.SystemConsole.Themes;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Data;

//SERILOG APPSETTINGS JSON
/*
public class Program
{
    static IServiceCollection services = new ServiceCollection();

    static IConfiguration configuration = new ConfigurationBuilder()
        //.SetBasePath(System.IO.Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    static ServiceProvider? serviceProvider;

    //static Serilog.ILogger seriLogger = new LoggerConfiguration()
    //    .MinimumLevel.Information()
    //    .WriteTo.Console(theme: AnsiConsoleTheme.Code, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    //    .CreateLogger();

    private static void Main(string[] args)
    {
        Serilog.Log.Logger = new LoggerConfiguration()
        //.MinimumLevel.Information()
        //.WriteTo.Console(theme: AnsiConsoleTheme.Code, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

        //services.AddSingleton(Serilog.Log.Logger);

        services.AddLogging(builder =>
        {

            //builder.SetMinimumLevel(LogLevel.Warning);
            //builder.AddFilter(nameof(Program), LogLevel.Information);

            //builder.AddConfiguration(configuration.GetSection("Logging"));

            //builder.AddJsonConsole(x =>
            //{
            //    x.IncludeScopes = true;
            //    x.TimestampFormat = "HH:mm:ss";
            //    x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
            //    {
            //        Indented = true
            //    };
            //});

            //builder.AddDebug();

            //builder.AddSerilog(seriLogger);

            builder.AddSerilog();

        });

        serviceProvider = services.BuildServiceProvider();

        ILogger<Program> logger = serviceProvider.GetRequiredService<ILogger<Program>>();

        logger.BeginScope("Main");
        logger.LogInformation("Starting application {@user} {@time} ", new
        {
            Name = "Ali",
            Surname = "Veli",
            Age = 25,
            Date = DateTime.Now

        }, DateTime.Now.Minute);


        logger.LogWarning("Starting application {@user} {@time} ", new
        {
            Name = "Emre",
            Surname = "Demirkan",
            Age = 25,
            Date = DateTime.Now

        }, DateTime.Now.Minute);

        Console.Read();
    }
}
*/


//DOTNET LOGGING - SERILOG

/*
internal class Program
{
    static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddJsonConsole(x =>
        {
            x.IncludeScopes = true;
            x.TimestampFormat = "G";
            x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
            {
                Indented = true
            };
        });
        builder.AddDebug();
    });

    static ILogger<Program> programlogger => loggerFactory.CreateLogger<Program>();

    static string template = "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:1j}{NewLine}{Exception}{NewLine}]";
    static string connStr = "server = EMRE; database = SERILOGDB; integrated security = true; TrustServerCertificate = True;";

    static Serilog.ILogger seriLogger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", "ConsoleUI")
        .Enrich.WithProperty("Environment", "Development")
        .Enrich.WithProperty("MachineName", System.Environment.MachineName)
        .Enrich.WithProperty("ProcessId", System.Diagnostics.Process.GetCurrentProcess().Id)
        .Enrich.WithProperty("ThreadId", System.Environment.UserName)
        .Enrich.WithProperty("Version", "1.0.0")
        .Enrich.WithProperty("CustomProperty", "CustomValue")
        .Enrich.WithProperty("CustomProperty", "CustomValue2")

        .MinimumLevel.Information()
        .MinimumLevel.Override(nameof(Program), Serilog.Events.LogEventLevel.Information)

        .WriteTo.Console(outputTemplate: template, theme: AnsiConsoleTheme.Literate)
        .WriteTo.Console(theme: AnsiConsoleTheme.Code, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
        .WriteTo.Console(outputTemplate: template, theme: AnsiConsoleTheme.Code)

        .WriteTo.Debug()
        //.WriteTo.File("logs/log.json", rollingInterval: RollingInterval.Day)
        .WriteTo.File(new CompactJsonFormatter(), "logs/log.json", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
        //.ReadFrom.Configuration(configuration)
        
        .WriteTo.MSSqlServer(connectionString:connStr,restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
        sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
        {
            TableName = "LogEvents",
            AutoCreateSqlDatabase = true,
            AutoCreateSqlTable = true
        })

        .CreateLogger();

    private static void Main(string[] args)
    {
        Serilog.Log.Logger = seriLogger;

        loggerFactory.AddSerilog(seriLogger);

        programlogger.BeginScope("Main");
        programlogger.LogInformation("Deneme {@user},{@time}", new
        {
            Name = "Emre",
            Surname = "Demir",
            Age = 25,
        }, DateTime.Now.Minute);

        var exception = new Exception("Hata Oluştu");
        programlogger.LogError(exception,"Deneme {@user},{@time}", new
        {
            Name = "Emre",
            Surname = "Demir",
            Age = 25,
        },DateTime.Now.Minute);

        //programlogger.LogInformation("Deneme {@user},{@time}", new
        //{
        //    Name = "Emre",
        //    Surname = "Demirkan",
        //    Age = 25,
        //}, DateTime.Now.Minute);

        //programlogger.Log(LogLevel.Information, "Deneme {@user},{@time}", new
        //{
        //    Name = "Züleyha",
        //    Surname = "Şen",
        //    Age = 23,
        //}, DateTime.Now.Minute);

        Serilog.Log.CloseAndFlush();

        Console.Read();


    }
}
*/

//SERILOG ASPNETCORE
/*
internal class Program
{
    static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddJsonConsole(x =>
        {
            x.IncludeScopes = true;
            x.TimestampFormat = "G";
            x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
            {
                Indented = true
            };
        });
        builder.AddDebug();
    });

    static ILogger<Program> logger => loggerFactory.CreateLogger<Program>();

    static string template = "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:1j}{NewLine}{Exception}{NewLine}]";

    static Serilog.ILogger seriLogger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application","ConsoleUI")
        .Enrich.WithProperty("Environment","Development")
        .Enrich.WithProperty("MachineName",System.Environment.MachineName)
        .Enrich.WithProperty("ProcessId",System.Diagnostics.Process.GetCurrentProcess().Id)
        .Enrich.WithProperty("ThreadId",System.Environment.UserName)
        .Enrich.WithProperty("Version","1.0.0")
        .Enrich.WithProperty("CustomProperty","CustomValue")
        .Enrich.WithProperty("CustomProperty","CustomValue2")
        
        .MinimumLevel.Information()
        .MinimumLevel.Override(nameof(Program),Serilog.Events.LogEventLevel.Warning)

        .WriteTo.Console(outputTemplate:template,theme:AnsiConsoleTheme.Literate)
        .WriteTo.Console(theme:AnsiConsoleTheme.Code,restrictedToMinimumLevel:Serilog.Events.LogEventLevel.Information)
        .WriteTo.Console(outputTemplate:template,theme:AnsiConsoleTheme.Code)
        
        .WriteTo.Debug()
        //.WriteTo.File("logs/log.json", rollingInterval: RollingInterval.Day)
        .WriteTo.File(new CompactJsonFormatter(),"logs/log.json",rollingInterval:RollingInterval.Day,restrictedToMinimumLevel:Serilog.Events.LogEventLevel.Information)
        //.ReadFrom.Configuration(configuration)
        .CreateLogger();

    public static void Main (string[] args)
    {
        logger.LogInformation("Deneme {@user},{@time}",new 
        {
            Name = "Emre",
            Surname = "Demirkan",
            Age = 25
        
        },DateTime.Now.Minute);

        logger.Log(LogLevel.Information, "Deneme {@user},{@time}", new
        {
            Name = "Emre",
            Surname = "Demirkan",
            Age = 25
        }, DateTime.Now.Minute);

        Serilog.Log.Logger = seriLogger;

        Serilog.Log.Write(Serilog.Events.LogEventLevel.Information, "Deneme {@user},{@time}", new
        {
            Name = "Emre",
            Surname = "Demirkan",
            Age = 25,
        }, DateTime.Now.Minute);

        seriLogger.Warning("Deneme {@user},{@time}", new
        {
            Name = "Züleyha",
            Surname = "Şen",
            Age = 23,
        }, DateTime.Now.Minute);
        
        Console.Read();

    }

}
*/

//DEPENDENCY INJECTION ADD & PROGRAM
/*
internal class Program
{
    static IServiceCollection services = new ServiceCollection();
    
    static IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();
    
    static ServiceProvider? serviceProvider;

    private static void Main(string[] args)
    {
        services.AddScoped<Deneme>();
        
        services.AddLogging(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Warning);
            builder.AddFilter(nameof(Program), LogLevel.Information);

            builder.AddConfiguration(configuration.GetSection("Logging"));

            builder.AddJsonConsole(x =>
            {
                x.IncludeScopes = true;
                x.TimestampFormat = "G";
                x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
                {
                    Indented = true
                };
            });
            builder.AddDebug();
        });

        serviceProvider = services.BuildServiceProvider();

        ILogger<Program> logger = serviceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogInformation("STARTING APPLICATION");

        logger.LogWarning("WARNING MESSAGE");

        var deneme = serviceProvider.GetRequiredService<Deneme>();

        deneme.Test();

        Console.Read();
    
    }
}
*/


//DI LOGGING
/*
internal class Program
{
    static IServiceCollection services = new ServiceCollection();

    static IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

    static ServiceProvider? serviceProvider;
    private static void Main(string[] args)
    {
        services.AddLogging(builder =>
        {
            builder.AddConfiguration(new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build().GetSection("Logging")
                );
            
            builder.AddJsonConsole(x =>
            {
                x.IncludeScopes = true;
                x.TimestampFormat = "G";
                x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
                {
                    Indented = true
                };
            });
            builder.AddDebug();
        });
        serviceProvider = services.BuildServiceProvider();
        ILogger<Program> logger = services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
        logger.LogInformation("STARTING APPLICATION");
        logger.LogWarning("WARNING MESSAGE");

        Console.Read();
    }
}
*/


//DOTNET LOGGING
/*
internal class Program
{
    static IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    static IConfiguration configuration = configurationBuilder.Build();

    static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.SetMinimumLevel(configuration.GetValue<LogLevel>("Logging:LogLevel:Default"));
        builder.AddFilter(nameof(Program),configuration.GetValue<LogLevel>("Logging:LogLevel:Program"));
        //builder.AddConsole();
        builder.AddJsonConsole(x =>
        {
            x.IncludeScopes = true;
            x.TimestampFormat = "G";
            x.JsonWriterOptions = new System.Text.Json.JsonWriterOptions
            {
                Indented = true
        };
        });
        builder.AddDebug();
    });

    static ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

    private static void Main(string[] args)
    {
        //logger.LogInformation("STARTING APPLICATION");
        //logger.LogTrace("TRACE MESSAGE");
        //logger.LogWarning("WARNING MESSAGE");

        logger.BeginScope("Main");
        logger.Log(LogLevel.Information, "MY INFO MESSAGE: {} DATE MESSAGED:{}","message1",DateTime.Now);
        TEST();

        Console.Read();
    }

    public static void TEST()
    {
        logger.BeginScope("TEST");
        logger.LogInformation("TEST {} TEST1: {}","REPEAT FOR TEST",123);

    }
}
*/