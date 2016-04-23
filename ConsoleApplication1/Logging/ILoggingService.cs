

using System;

namespace ConsoleApplication1.Logging
{
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