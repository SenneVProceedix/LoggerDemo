using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo
{
    /**
     * Default minimum level is Information.
     */
    class FactoryHelper
    {
        /**
         * Add Microsoft.Extensions.Logging.Console
         */
        public static ILoggerFactory CreateConsoleLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
        }
        /**
         * Add SeriLog.Extensions.Logging.File
         * You can find the file under ProjectFolder/bin/Debug/netcoreapp3.1/Logs
         */
        public static ILoggerFactory CreateFileLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddFile("Logs/demo-log-{Date}.txt");
            });
        }

        /**
         * Add Microsoft.Extensions.Logging.ApplicationInsights
         * Note that it takes a while before the logs are visible in application insight
         */
        public static ILoggerFactory CreateInsightLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddApplicationInsights("15c1723b-5b68-42bf-9040-15d2efdca2fc", options => { options.FlushOnDispose = true;});
            });           
        }
        /**
         * Add Microsoft.Extensions.Logging.EventLog
         * The default minimum filter is Warning
         * To view these event logs open "Event Viewer" or execute "Get-EventLog -LogName Application -Newest 10" in PowerShell
         */
        public static ILoggerFactory CreateEventLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddEventLog();
            });
        }
        /**
         * Add Microsoft.Extensions.Logging.Debug
         * This logger logs messages to a debugger monitor by writing messages with System.Diagnostics.Debug.WriteLine().
         */
        public static ILoggerFactory CreateDebugLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
        }
        /**
         * Add Microsoft.Extensions.Configuration & Microsoft.Extensions.Json
         * Make sure that the json file is set to copy always
         */
        public static ILoggerFactory CreateLoggerFactoryWithSettings()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddConsole()
                .AddFile("Logs/demo-log-{Date}.txt")
                .AddEventLog()
                .AddDebug()
                .AddApplicationInsights("15c1723b-5b68-42bf-9040-15d2efdca2fc", options => { options.FlushOnDispose = true;})
                .AddConfiguration(new ConfigurationBuilder().AddJsonFile("logging.json").Build());
            });
        }
    }
}
