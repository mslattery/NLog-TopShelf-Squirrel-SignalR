using System;
using System.Reflection;
using ConsoleApplication1.Logging;
using ConsoleApplication1.Logging.NLog;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Topshelf;

namespace ConsoleApplication1
{


    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggingService>().To<NLogService>();
        }
    }

    internal static class Program
    {
        private static void Main()
        {
            ILoggingService loggingService;
            // NinJect
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Load(Assembly.GetExecutingAssembly());
                IParameter parameter = new ConstructorArgument("callingClassName", "ServiceMain");
                loggingService = kernel.Get<ILoggingService>(parameter);
            }

            // TopShelf
            HostFactory.Run(x =>
            {
                x.Service<ServiceMain>(s =>
                {
                    s.ConstructUsing(name => new ServiceMain(loggingService));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.UseNLog();    // Logger

                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("Stuff");
                x.SetServiceName("Stuff");
            });
        }
    }
}