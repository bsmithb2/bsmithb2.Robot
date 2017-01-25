using NSubstitute;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using bsmithb2.Robot.core;
using bsmithb2.Robot.core.Interfaces;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        [Test]
        public void Constructor_ShouldAccept_ILogger()
        {
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, null);
        }

        [Test]
        public void Constructor_ShouldLogItsInstantiation()
        {
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, null);

            logger.ReceivedWithAnyArgs(1).LogDebug("testmessage");
        }

        [Test]
        public void Constructor_ShouldAccept_IConsoleReader()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, consoleReader);
        }
    }
}
