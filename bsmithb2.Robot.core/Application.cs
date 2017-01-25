using bsmithb2.Robot.core.Interfaces;
using Microsoft.Extensions.Logging;

namespace bsmithb2.Robot.core
{
    public class Application : IApplication
    {
        private ILogger _logger;
        private IConsoleReader _consoleReader;
        private ICommandParser _commandParser;

        public Application(ILogger logger, IConsoleReader consoleReader, ICommandParser commandParser)
        {
            _logger = logger;
            _consoleReader = consoleReader;
            _commandParser = commandParser;

            _logger.LogDebug("Started application");
        }

        public void Run()
        {
            _logger.LogDebug("Beginning Run");
            var firstInstruction = _consoleReader.ReadLine();
        }
    }
}