using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerDemo
{
    class LogExample
    {
        public void LogToAll()
        {
            log(FactoryHelper.CreateConsoleLoggerFactory(), "the console");
            log(FactoryHelper.CreateFileLoggerFactory(), "a file");
            log(FactoryHelper.CreateInsightLoggerFactory(), "applications insights");
            log(FactoryHelper.CreateEventLoggerFactory(), "event logs");
            log(FactoryHelper.CreateDebugLoggerFactory(), "debug monitor");
        }

        public void LogWithConfig()
        {
            log(FactoryHelper.CreateLoggerFactoryWithSettings(), "all with config");
        }

        private void log(ILoggerFactory loggerFactory, string target)
        {
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogTrace("Trace log to " + target);
            logger.LogDebug("Debug log to " + target);
            logger.LogInformation("Information log to " + target);
            logger.LogWarning("Warning log to " + target);
            logger.LogError(new Exception("custom exception"), "Error log to " + target);
            logger.LogCritical("Critical log to " + target);
            loggerFactory.Dispose();
        }
    }
}
