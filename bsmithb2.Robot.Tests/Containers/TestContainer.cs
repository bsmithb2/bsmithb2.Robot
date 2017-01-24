using Autofac;
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
            //builder.RegisterType<>().As<IApplication>();
            return builder.Build();
        }
    }
}
