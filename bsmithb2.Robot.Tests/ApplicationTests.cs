using NSubstitute;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using bsmithb2.Robot.core;
using bsmithb2.Robot.core.Interfaces;
using bsmithb2.Robot.core.Actions;

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

        [Test]
        public void Run_ShouldRecordInputOfPLACECommandToList()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().ReturnsForAnyArgs("PARSE");
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            commandParser.ParseCommand("PARSE").Returns(new PlaceAction(0,0,"NORTH"));

            var application = new Application(logger, consoleReader, commandParser);

            application.Run();

            commandParser.Received(1).ParseCommand("PARSE");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(1, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldNotRecordInputOfMOVECommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().ReturnsForAnyArgs("MOVE");
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            commandParser.ParseCommand("MOVE").Returns(new MoveAction());

            var application = new Application(logger, consoleReader, commandParser);

            application.Run();

            commandParser.Received(1).ParseCommand("MOVE");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldNotRecordInputOfLEFTCommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().ReturnsForAnyArgs("LEFT");
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            commandParser.ParseCommand("LEFT").Returns(new LeftAction());

            var application = new Application(logger, consoleReader, commandParser);

            application.Run();

            commandParser.Received(1).ParseCommand("LEFT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldNotRecordInputOfRIGHTCommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().ReturnsForAnyArgs("RIGHT");
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            commandParser.ParseCommand("RIGHT").Returns(new RightAction());

            var application = new Application(logger, consoleReader, commandParser);

            application.Run();

            commandParser.Received(1).ParseCommand("RIGHT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldNotRecordInputOfREPORTCommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().ReturnsForAnyArgs("REPORT");
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            commandParser.ParseCommand("REPORT").Returns(new ReportAction());

            var application = new Application(logger, consoleReader, commandParser);

            application.Run();

            commandParser.Received(1).ParseCommand("REPORT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }
    }
}
