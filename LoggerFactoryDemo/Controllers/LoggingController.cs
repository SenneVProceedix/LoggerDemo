using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace LoggerFactoryDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            this.logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            logger.LogTrace(LoggingEvent.ProcessStarted, "Log a trace message with {id}", 1);
            logger.LogDebug(LoggingEvent.ProcessInProgress, "Log a debug message with {id}", 2);
            logger.LogInformation(LoggingEvent.ProcessFinished, "Log a information message with {id}", 3);
            logger.LogWarning(LoggingEvent.ProcessError, "Log a warning message with {id}", 4);
            logger.LogError(LoggingEvent.ProcessError, "Log an error message with {id}", 5);
            logger.LogError(LoggingEvent.ProcessError, new Exception("something happened"), "log an exception with {id}", 6);
            logger.LogCritical(LoggingEvent.ProcessError, "Log a critical message with {id}", 7);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("A structured log message has been send to the following providers:\n")
                .Append(" - Console, Levels Information -> Critical\n")
                .Append(" - Debug, Levels Debug - Critical\n")
                .Append(" - File, Levels Trace -> Critical\n")
                .Append(" - Event Log, Levels Warning -> Critical\n")
                .Append(" - Application Insight, Levels Error -> Critical (when adding an exception, the log can be found back in the exception table. Otherwise in the trace table.)\n\n")
                .Append("You can find the configuration of the Log Levels in the appsettings.json file.\n\n")
                .Append("Go to logging/scope");

            return stringBuilder.ToString();
        }
        [Route("scope")]
        public string Scope()
        {
            using (logger.BeginScope("message {messageId}", 14)) {
                logger.LogTrace("Log a trace message");
                logger.LogDebug("Log a debug message");
                logger.LogInformation("Log a information message");
                logger.LogWarning("Log a warning message");
                logger.LogError("Log an error message");
                logger.LogError(new Exception("something happened"), "log an exception");
                logger.LogCritical("Log a critical message");
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("A log message has been send with a scope:\n")
                .Append("The scope is a structured message with meassageId 14\n")
                .Append("The scope will only be visible for the providers where IncludeScopes is enabled. (see appsettings.json)\n\n")
                .Append("Go to /logging");
            return stringBuilder.ToString();
        }
    }
}
