using bsmithb2.Robot.core.Interfaces;
using Microsoft.Extensions.Logging;

namespace bsmithb2.Robot.core
{
    public class Application : IApplication
    {
        private ILogger logger;

        public Application(ILogger logger)
        {
            this.logger = logger;

            logger.LogDebug("Started application");
        }

        public void Run()
        {
            
        }
    }
}