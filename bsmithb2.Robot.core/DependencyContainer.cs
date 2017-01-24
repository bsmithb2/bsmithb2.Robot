using Autofac;
using bsmithb2.Robot.core.Interfaces;

namespace bsmithb2.Robot.core
{
    internal class DependencyContainer
    {
        internal IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            return builder.Build();
        }
    }
}