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
        [SetUp]
        public void BeforeTest()
        {
            countOfCalls = 0;
        }

        [Test]
        public void Constructor_ShouldAccept_ILogger()
        {
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, null, null, null);
        }

        [Test]
        public void Constructor_ShouldLogItsInstantiation()
        {
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, null, null, null);

            logger.ReceivedWithAnyArgs(1).LogDebug("");
        }

        [Test]
        public void Constructor_ShouldAccept_IConsoleReader()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var application = new Application(logger, consoleReader, null, null);
        }

        [Test]
        public void Run_ShouldNoteStartInLog()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            commandParser.ParseCommand("").ReturnsForAnyArgs(new ExitAction());
            var application = new Application(logger, consoleReader, commandParser, null);
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
            var reportGenerator = Substitute.For<IReportGenerator>();
            commandParser.ParseCommand("").ReturnsForAnyArgs(new ExitAction());
            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            consoleReader.Received(1).ReadLine();
        }

        [Test]
        public void Run_ShouldIgnoreInvalidActions()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("MOEV", "EXIT"));
            commandParser.ParseCommand("MOEV").Returns((IAction)null);
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());
            
            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            consoleReader.Received(2).ReadLine();
        }

        [Test]
        public void Run_ShouldPassInputToCommandParser()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("TEST", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();
            
            commandParser.Received(1).ParseCommand("TEST");
        }

        [Test]
        public void Run_ShouldRecordInputOfPLACECommandToList()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("PLACE", "EXIT"));
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            commandParser.ParseCommand("PLACE").Returns(new PlaceAction(0,0,"NORTH"));
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("PLACE");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(1, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldNotRecordInputOfMOVECommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("MOVE", "EXIT"));
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            commandParser.ParseCommand("MOVE").Returns(new MoveAction());
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("MOVE");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldNotRecordInputOfLEFTCommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("LEFT", "EXIT"));
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            commandParser.ParseCommand("LEFT").Returns(new LeftAction());
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("LEFT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldNotRecordInputOfRIGHTCommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("RIGHT", "EXIT"));
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            commandParser.ParseCommand("RIGHT").Returns(new RightAction());
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("RIGHT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }

        private int countOfCalls = 0;
        private string BuildListOfItemsInOrder(params string[] items)
        {
            var item = items[countOfCalls];
            countOfCalls++;
            return item;
        }

        [Test]
        public void Run_ShouldNotRecordInputOfREPORTCommandToList_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            countOfCalls = 0;
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("REPORT", "EXIT"));
            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();

            commandParser.ParseCommand("REPORT").Returns(new ReportAction());
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("REPORT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(0, application.Actions.Count);
        }


        [Test]
        public void Run_ShouldResetListOnInputOfPLACECommandToList_IfSecond()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("PLACE", "PLACE", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            commandParser.ParseCommand("PLACE").Returns(new PlaceAction(1,1,"WEST"));
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(2).ParseCommand("PLACE");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(1, application.Actions.Count);
        }

        [Test]
        public void Run_ShouldRecordInputOfMOVECommandToList_IfSecond()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("PLACE", "MOVE", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            var expectedAction1 = new PlaceAction(1, 1, "WEST");
            var expectedAction2 = new MoveAction();

            commandParser.ParseCommand("PLACE").Returns(expectedAction1);
            commandParser.ParseCommand("MOVE").Returns(expectedAction2);
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("PLACE");
            commandParser.Received(1).ParseCommand("MOVE");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(2, application.Actions.Count);
            Assert.AreSame(expectedAction1, application.Actions[0]);
            Assert.AreSame(expectedAction2, application.Actions[1]);
        }

        [Test]
        public void Run_ShouldRecordInputOfRIGHTCommandToList_IfSecond()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("PLACE", "RIGHT", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            var expectedAction1 = new PlaceAction(1, 1, "WEST");
            var expectedAction2 = new RightAction();

            commandParser.ParseCommand("PLACE").Returns(expectedAction1);
            commandParser.ParseCommand("RIGHT").Returns(expectedAction2);
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("PLACE");
            commandParser.Received(1).ParseCommand("RIGHT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(2, application.Actions.Count);
            Assert.AreSame(expectedAction1, application.Actions[0]);
            Assert.AreSame(expectedAction2, application.Actions[1]);
        }

        [Test]
        public void Run_ShouldRecordInputOfLEFTCommandToList_IfSecond()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("PLACE", "LEFT", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            var expectedAction1 = new PlaceAction(1, 1, "WEST");
            var expectedAction2 = new RightAction();

            commandParser.ParseCommand("PLACE").Returns(expectedAction1);
            commandParser.ParseCommand("LEFT").Returns(expectedAction2);
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("PLACE");
            commandParser.Received(1).ParseCommand("LEFT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(2, application.Actions.Count);
            Assert.AreSame(expectedAction1, application.Actions[0]);
            Assert.AreSame(expectedAction2, application.Actions[1]);
        }

        [Test]
        public void Run_ShouldRecordInputOfREPORTCommandToList_IfSecond()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("PLACE", "REPORT", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            var expectedAction1 = new PlaceAction(1, 1, "WEST");
            var expectedAction2 = new RightAction();

            commandParser.ParseCommand("PLACE").Returns(expectedAction1);
            commandParser.ParseCommand("REPORT").Returns(expectedAction2);
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("PLACE");
            commandParser.Received(1).ParseCommand("REPORT");
            Assert.IsNotNull(application.Actions);
            Assert.AreEqual(2, application.Actions.Count);
            Assert.AreSame(expectedAction1, application.Actions[0]);
            Assert.AreSame(expectedAction2, application.Actions[1]);
        }

        [Test]
        public void Run_ShouldNotRunReport_IfFirst()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("REPORT", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();

            var expectedAction1 = new ReportAction();

            commandParser.ParseCommand("REPORT").Returns(expectedAction1);
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);

            application.Run();

            commandParser.Received(1).ParseCommand("REPORT");
            reportGenerator.ReceivedWithAnyArgs(0).RunReport(null);
        }

        [Test]
        public void Run_ShouldRunReport_IfSecond_AndLogOutput()
        {
            var consoleReader = Substitute.For<IConsoleReader>();
            consoleReader.ReadLine().Returns(i => BuildListOfItemsInOrder("PLACE", "REPORT", "EXIT"));

            var logger = Substitute.For<ILogger>();
            var commandParser = Substitute.For<ICommandParser>();
            var reportGenerator = Substitute.For<IReportGenerator>();
            reportGenerator.RunReport(null).ReturnsForAnyArgs("TestOutput");

            var expectedAction1 = new ReportAction();

            commandParser.ParseCommand("PLACE").Returns(new PlaceAction(1,1, "WEST"));
            commandParser.ParseCommand("REPORT").Returns(expectedAction1);
            commandParser.ParseCommand("EXIT").Returns(new ExitAction());

            var application = new Application(logger, consoleReader, commandParser, reportGenerator);
            logger.ClearReceivedCalls();
            application.Run();

            reportGenerator.ReceivedWithAnyArgs(1).RunReport(null);
            logger.ReceivedWithAnyArgs(2).LogInformation("");
        }
    }
}
