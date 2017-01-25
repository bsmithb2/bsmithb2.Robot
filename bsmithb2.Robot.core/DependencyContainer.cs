using Autofac;
using bsmithb2.Robot.core.Interfaces;
using Microsoft.Extensions.Logging;

namespace bsmithb2.Robot.core
{
    public class DependencyContainer
    {
        public IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            ILoggerFactory loggerFactory = new LoggerFactory()    
                .AddConsole()
                .AddDebug();
            ILogger logger = loggerFactory.CreateLogger<Program>();
            builder.RegisterInstance<ILogger>(logger);

            builder.RegisterType<ConsoleReader>().As<IConsoleReader>();
            return builder.Build();
        }
    }
}