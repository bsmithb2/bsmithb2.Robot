using Autofac;
using bsmithb2.Robot.core;
using bsmithb2.Robot.core.Interfaces;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class DependencyContainerTests
    {
        [Test]
        public void Configure_ShouldResolveApplication()
        {
            DependencyContainer dependencyContainer = new DependencyContainer();
            var container = dependencyContainer.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                Assert.IsNotNull(app);
                Assert.IsInstanceOf<core.Application>(app);
            }
        }

        [Test]
        public void Configure_ShouldResolveLogger()
        {
            DependencyContainer dependencyContainer = new DependencyContainer();
            var container = dependencyContainer.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var logger = scope.Resolve<ILogger>();
                Assert.IsNotNull(logger);
                Assert.IsInstanceOf<ILogger<Program>>(logger);
            }
        }

        [Test]
        public void Configure_ShouldResolveConsoleReader()
        {
            DependencyContainer dependencyContainer = new DependencyContainer();
            var container = dependencyContainer.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var reader = scope.Resolve<IConsoleReader>();
                Assert.IsNotNull(reader);
                Assert.IsInstanceOf<ConsoleReader>(reader);
            }
        }

        [Test]
        public void Configure_ShouldResolveCommandParser()
        {
            DependencyContainer dependencyContainer = new DependencyContainer();
            var container = dependencyContainer.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var reader = scope.Resolve<ICommandParser>();
                Assert.IsNotNull(reader);
                Assert.IsInstanceOf<CommandParser>(reader);
            }
        }

        [Test]
        public void Configure_ShouldResolveReportGenerator()
        {
            DependencyContainer dependencyContainer = new DependencyContainer();
            var container = dependencyContainer.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var reader = scope.Resolve<IReportGenerator>();
                Assert.IsNotNull(reader);
                Assert.IsInstanceOf<ReportGenerator>(reader);
            }
        }
    }
}
