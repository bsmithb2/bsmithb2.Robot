using NSubstitute;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class ApplicationTests
    {
        [Test]
        public void Constructor_ShouldAccept_ILogger()
        {
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger);
        }

        [Test]
        public void Constructor_ShouldLogItsInstantiation()
        {
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger);

            logger.ReceivedWithAnyArgs(1).LogDebug("testmessage");
        }
    }
}
