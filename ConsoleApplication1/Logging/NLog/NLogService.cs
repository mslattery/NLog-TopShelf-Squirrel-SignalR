using NLog;
using System;

namespace ConsoleApplication1.Logging.NLog
{
    public class NLogService : ILoggingService
    {
        private static Logger _logger;

        public NLogService(string callingClassName)
        {
            _logger = LogManager.GetLogger(callingClassName);
        }

        public void Log(LogLevelEnum logLevelEnum, string logMessage)
        {
            Log(null, logLevelEnum, logMessage);
        }

        public void Log(Exception ex, LogLevelEnum logLevelEnum, string logMessage)
        {
            LogLevel logLevel;

            switch (logLevelEnum)
            {
                case LogLevelEnum.Trace:
                    logLevel = LogLevel.Trace;
                    break;

                case LogLevelEnum.Debug:
                    logLevel = LogLevel.Debug;
                    break;

                case LogLevelEnum.Info:
                    logLevel = LogLevel.Info;
                    break;

                case LogLevelEnum.Error:
                    logLevel = LogLevel.Error;
                    break;

                case LogLevelEnum.Warning:
                    logLevel = LogLevel.Warn;
                    break;

                case LogLevelEnum.Fatal:
                    logLevel = LogLevel.Fatal;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevelEnum), logLevelEnum, null);
            }

            _logger.Log(logLevel, ex, logMessage);
        }
    }
}