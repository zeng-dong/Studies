using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using TablePerHierarchy.ConcreteBaseClass;

namespace TablePerHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Explicit");
            //ExplicitApp.Run();
            //
            //Console.WriteLine("Implicit");
            //ImplicitApp.Run();

            AccountApp.Run();

            Console.ReadLine();
        }


        static void SetUp()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var services = ConfigureServicesProvider(config);
            services.AddSingleton(config);
            //_servicesProvider = services.BuildServiceProvider();

            var level = config["Logging:LogLevel:Default"].ToString();

            var lc = new LoggerConfiguration().MinimumLevel.Information();
            switch (level)
            {
                case "Debug":
                    lc.MinimumLevel.Debug();
                    break;
                case "Warn":
                    lc.MinimumLevel.Warning();
                    break;
                case "Error":
                    lc.MinimumLevel.Error();
                    break;
                default:
                    break;
            }

            Log.Logger = lc
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)

                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    "log.txt",
                    rollingInterval: RollingInterval.Day,
                    fileSizeLimitBytes: 1_000_000,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1)
                 )
                .CreateLogger();
        }

        private static IServiceCollection ConfigureServicesProvider(IConfiguration config)
        {
            var services = new ServiceCollection();

            services.AddLogging(configure =>
                configure.AddSerilog()
            )
            .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug)
            ;

            return services;
        }

    }
}
