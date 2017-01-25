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
            var command = commandParser.ParseCommand("PLACE 1,Y,F");
            Assert.IsAssignableFrom<PlaceAction>(command);
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
    }
}
