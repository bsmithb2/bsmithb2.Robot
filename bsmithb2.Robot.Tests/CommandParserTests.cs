using bsmithb2.Robot.core;
using bsmithb2.Robot.core.Actions;
using NUnit.Framework;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class CommandParserTests
    {
        [Test]
        public void ParseCommand_ShouldParsePlaceCommand()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 1,2,SOUTH");
            Assert.IsAssignableFrom<PlaceAction>(command);
            Assert.AreEqual(1, ((PlaceAction)command).PositionX);
            Assert.AreEqual(2, ((PlaceAction)command).PositionY);
            Assert.AreEqual(Direction.SOUTH, ((PlaceAction)command).Direction);
        }

        [Test]
        public void ParseCommand_ShouldNotParsePlaceCommand_MissingSpace()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACEX,Y,F");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_ShouldNotParsePlaceCommand_NotEnoughParameters()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE X,Y");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_ShouldNotParsePlaceCommand_TooManyParameters()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE X,Y,F,A");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_ShouldNotParseAnyCommand_WrongInput()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("HJLjdfkalhjfdklha");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_FirstParameter_Between0And4()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 1,2,NORTH");
            Assert.IsAssignableFrom<PlaceAction>(command);
            Assert.AreEqual(1, ((PlaceAction)command).PositionX);
            Assert.AreEqual(2, ((PlaceAction)command).PositionY);
            Assert.AreEqual(Direction.NORTH, ((PlaceAction)command).Direction);
        }

        [Test]
        public void ParseCommand_FirstParameter_NotANumber()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE X,2,NORTH");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_FirstParameter_NegativeNumber()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE -1,2,NORTH");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_FirstParameter_PositiveNumber_Five()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 5,2,NORTH");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_SecondParameter_Between0And4()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 1,2,NORTH");
            Assert.IsAssignableFrom<PlaceAction>(command);
            Assert.AreEqual(1, ((PlaceAction)command).PositionX);
            Assert.AreEqual(2, ((PlaceAction)command).PositionY);
            Assert.AreEqual(Direction.NORTH, ((PlaceAction)command).Direction);
        }

        [Test]
        public void ParseCommand_SecondParameter_NotANumber()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 1,X,NORTH");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_SecondParameter_NegativeNumber()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 1,-1,NORTH");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_SecondParameter_PositiveNumber_Five()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 2,5,NORTH");
            Assert.IsNull(command);
        }

        [Test]
        public void ParseCommand_DirectionParameter_NORTH()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 2,4,NORTH");
            Assert.IsAssignableFrom<PlaceAction>(command);
            Assert.AreEqual(2, ((PlaceAction)command).PositionX);
            Assert.AreEqual(4, ((PlaceAction)command).PositionY);
            Assert.AreEqual(Direction.NORTH, ((PlaceAction)command).Direction);
        }

        [Test]
        public void ParseCommand_DirectionParameter_SOUTH()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 2,4,SOUTH");
            Assert.IsAssignableFrom<PlaceAction>(command);
            Assert.AreEqual(2, ((PlaceAction)command).PositionX);
            Assert.AreEqual(4, ((PlaceAction)command).PositionY);
            Assert.AreEqual(Direction.SOUTH, ((PlaceAction)command).Direction);
        }

        [Test]
        public void ParseCommand_DirectionParameter_EAST()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 2,4,EAST");
            Assert.IsAssignableFrom<PlaceAction>(command);
            Assert.AreEqual(2, ((PlaceAction)command).PositionX);
            Assert.AreEqual(4, ((PlaceAction)command).PositionY);
            Assert.AreEqual(Direction.EAST, ((PlaceAction)command).Direction);
        }

        [Test]
        public void ParseCommand_DirectionParameter_WEST()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("PLACE 2,4,WEST");
            Assert.IsAssignableFrom<PlaceAction>(command);

            Assert.AreEqual(2, ((PlaceAction)command).PositionX);
            Assert.AreEqual(4, ((PlaceAction)command).PositionY);
            Assert.AreEqual(Direction.WEST, ((PlaceAction)command).Direction);
        }

        [Test]
        public void MoveCommand_ReturnsMoveAction()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("MOVE");
            Assert.IsAssignableFrom<MoveAction>(command);
        }

        [Test]
        public void LeftCommand_ReturnsLeftAction()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("LEFT");
            Assert.IsAssignableFrom<LeftAction>(command);
        }

        [Test]
        public void RightCommand_ReturnsRightAction()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("RIGHT");
            Assert.IsAssignableFrom<RightAction>(command);
        }

        [Test]
        public void ReportCommand_ReturnsReportAction()
        {
            var commandParser = new CommandParser();
            var command = commandParser.ParseCommand("REPORT");
            Assert.IsAssignableFrom<ReportAction>(command);
        }
    }
}
