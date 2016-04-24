using ConsoleApplication1.Logging;
using ConsoleApplication1.Logging.NLog;
using Ninject.Modules;

namespace ConsoleApplication1
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggingService>().To<NLogService>();
        }
    }
}