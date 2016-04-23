using ConsoleApplication1.Logging.NLog;
using Topshelf;

namespace ConsoleApplication1
{
    internal static class Program
    {
        private static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<ServiceMain>(s =>
                {
                    s.ConstructUsing(name =>
                        new ServiceMain(
                            new NLogService(typeof(ServiceMain).FullName)   // Logger
                        ));
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