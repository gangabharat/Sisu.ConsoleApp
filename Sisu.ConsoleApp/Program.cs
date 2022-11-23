//Depandancy Injection, Serilog, Settings Configure for Console Application
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Sisu.ConsoleApp;
using Sisu.ConsoleApp.Services;
using Sisu.ConsoleApp.Services.Interface;


var builder = new ConfigurationBuilder();
Configuration.BuildConfig(builder);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger.Information("Application Starting");

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        //Register Services 
        services.AddTransient<IGreetingService, GreetingService>();
    })
    .UseSerilog()
    .Build();


//Get the Service to Execute
var svc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
svc.Run();