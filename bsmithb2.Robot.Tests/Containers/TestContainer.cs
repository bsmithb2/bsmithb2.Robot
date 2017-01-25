using Autofac;
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
        internal IContainer Configure()
        {
            var builder = new ContainerBuilder();
            var sub = Substitute.For<IApplication>();
            builder.RegisterInstance(sub).As<IApplication>();
            
            return builder.Build();
        }
    }
}
