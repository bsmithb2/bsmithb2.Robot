using bsmithb2.Robot.core.Interfaces;
using Microsoft.Extensions.Logging;

namespace bsmithb2.Robot.core
{
    public class Application : IApplication
    {
        private ILogger _logger;
        private IConsoleReader _consoleReader;

        public Application(ILogger logger, IConsoleReader consoleReader)
        {
            _logger = logger;
            _consoleReader = consoleReader;

            logger.LogDebug("Started application");
        }

        public void Run()
        {
            
        }
    }
}