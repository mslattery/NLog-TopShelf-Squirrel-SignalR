

using System;

namespace ConsoleApplication1.Logging
{

    //TODO: https://blog.tonysneed.com/2011/10/09/using-nlog-with-dependency-injection/
    public enum LogLevelEnum
    {
        Trace,
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    };

    public interface ILoggingService
    {
        void Log(LogLevelEnum logLevelEnum, string logMessage);
        void Log(Exception ex, LogLevelEnum logLevelEnum, string logMessage);
    }
}