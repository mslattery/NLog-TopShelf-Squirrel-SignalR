using ConsoleApplication1.Logging;
using Ninject;
using Ninject.Parameters;
using System.Reflection;
using Topshelf;

namespace ConsoleApplication1
{
    internal static class Program
    {
        private static void Main()
        {
            // NinJect Setup
            ILoggingService loggingService;
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