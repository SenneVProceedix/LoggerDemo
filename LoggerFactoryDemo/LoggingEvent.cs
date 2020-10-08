using Microsoft.Extensions.Logging;

namespace LoggerFactoryDemo
{
    public class LoggingEvent
    {
        public static EventId ProcessStarted = new EventId(1001, "Process Started");
        public static EventId ProcessInProgress = new EventId(1002, "Process In Progress");
        public static EventId ProcessFinished = new EventId(1003, "Process Finished");
        public static EventId ProcessError = new EventId(1600, "Error Ocurred In Process");
    }
}
