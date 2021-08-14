﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace CarvedRockSportsShop.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var name = typeof(Program).Assembly.GetName().Name;

            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Assembly", name)
                // available sinks: https://github.com/serilog/serilog/wiki/Provided-Sinks
                // Seq: https://datalust.co/seq
                // Seq with Docker: https://docs.datalust.co/docs/getting-started-with-docker
                //.WriteTo.Seq(serverUrl: "http://host.docker.internal:5341")
                .WriteTo.Seq(serverUrl: "http://host.docker.internal:5341")
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .UseSerilog()

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
