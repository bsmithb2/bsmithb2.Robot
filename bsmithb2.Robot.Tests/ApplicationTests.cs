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
            var application = new Application(logger, null, null);
        }

        [Test]
        public void Constructor_ShouldLogItsInstantiation()
        {
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, null, null);

            logger.ReceivedWithAnyArgs(1).LogDebug("");
        }

        [Test]
        public void Constructor_ShouldAccept_IConsoleReader()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, consoleReader, null);
        }

        [Test]
        public void Run_ShouldNoteStartInLog()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var application = new Application(logger, consoleReader, commandParser);
            logger.ClearReceivedCalls();
            application.Run();

            logger.ReceivedWithAnyArgs(1).LogDebug("");
        }

        [Test]
        public void Run_ShouldAskConsoleReaderForInput()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var application = new Application(logger, consoleReader, commandParser);

            application.Run();

            consoleReader.Received(1).ReadLine();
        }

        [Test]
        public void Constructor_ShouldAcceptCommandParser()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var application = new Application(logger, consoleReader, commandParser);

            application.Run();

            consoleReader.Received(1).ReadLine();
        }

        [Test]
        public void Run_ShouldPassInputToCommandParser()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().ReturnsForAnyArgs("TEST");
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var application = new Application(logger, consoleReader, commandParser);

            application.Run();
            
            commandParser.Received(1).ParseCommand("TEST");
        }
    }
}
