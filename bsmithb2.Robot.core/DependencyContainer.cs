﻿using Autofac;
using bsmithb2.Robot.core.Interfaces;
using Microsoft.Extensions.Logging;

namespace bsmithb2.Robot.core
{
    public class DependencyContainer
    {
        public IContainer Configure()
        {
            var builder = new ContainerBuilder();
            
            ILoggerFactory loggerFactory = new LoggerFactory()    
                .AddConsole()
                .AddDebug();
            ILogger logger = loggerFactory.CreateLogger<Program>();
            builder.RegisterInstance(logger);

            builder.RegisterType<ConsoleReader>().As<IConsoleReader>();

            builder.RegisterType<CommandParser>().As<ICommandParser>();
            builder.RegisterType<ReportGenerator>().As<IReportGenerator>();
            builder.RegisterType<Application>().As<IApplication>();
            
            return builder.Build();
        }
    }
}