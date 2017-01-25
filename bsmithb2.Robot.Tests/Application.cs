using Microsoft.Extensions.Logging;

namespace bsmithb2.Robot.Tests
{
    internal class Application
    {
        private ILogger logger;

        public Application()
        {
        }

        public Application(ILogger logger)
        {
            this.logger = logger;

            logger.LogDebug("Started application");
        }
    }
}