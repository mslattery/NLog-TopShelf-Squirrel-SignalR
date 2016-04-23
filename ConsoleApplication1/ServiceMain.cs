using ConsoleApplication1.Logging;

namespace ConsoleApplication1
{
    public class ServiceMain
    {
        private readonly ILoggingService _logSvc;

        public ServiceMain(ILoggingService logService)
        {
            _logSvc = logService;
        }

        public void Start()
        {
            _logSvc.Log(LogLevelEnum.Info, "Service Start");
        }

        public void Stop()
        {
            _logSvc.Log(LogLevelEnum.Info, "Service Stop");
        }

        public void Pause()
        {
            _logSvc.Log(LogLevelEnum.Info, "Service Pause");
        }

        public void Continue()
        {
            _logSvc.Log(LogLevelEnum.Info, "Service Continue");
        }

        public void Shutdown()
        {
            _logSvc.Log(LogLevelEnum.Info, "Service Shutdown");
        }
    }
}