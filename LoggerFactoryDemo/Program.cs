using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices;
using Serilog;

namespace LoggerFactoryDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logger =>
                {
                    logger.ClearProviders()
                    .AddConsole()
                    .AddFile("demo-app-{Date}", isJson: true)
                    .AddDebug()
                    .AddEventLog()
                    .AddApplicationInsights("15c1723b-5b68-42bf-9040-15d2efdca2fc", options => { options.FlushOnDispose = true; });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
