﻿using Autofac;
using bsmithb2.Robot.core.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bsmithb2.Robot.Tests.Containers
{
    internal class TestContainer
    {
        internal IApplication Application
        {
            get;set;
        }

        internal IConsoleReader ConsoleReader
        {
            get; set;
        }

        internal IContainer Configure()
        {
            var builder = new ContainerBuilder();
            Application = Substitute.For<IApplication>();
            builder.RegisterInstance(Application).As<IApplication>();

            ConsoleReader = Substitute.For<IConsoleReader>();
            builder.RegisterInstance(ConsoleReader).As<IConsoleReader>();

            return builder.Build();
        }
    }
}
