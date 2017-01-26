using bsmithb2.Robot.core.Actions;
using bsmithb2.Robot.core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace bsmithb2.Robot.core
{
    public class Application : IApplication
    {
        private ILogger _logger;
        private IConsoleReader _consoleReader;
        private ICommandParser _commandParser;
        private IReportGenerator _reportGenerator;

        public List<IAction> Actions
        {
            get;
            private set;
        }

        public Application(ILogger logger, IConsoleReader consoleReader, ICommandParser commandParser, IReportGenerator reportGenerator)
        {
            _logger = logger;
            _consoleReader = consoleReader;
            _commandParser = commandParser;
            _reportGenerator = reportGenerator;

            _logger.LogDebug("Started application");
        }

        public void Run()
        {
            _logger.LogDebug("Beginning Run");
            Actions = new List<IAction>();
            while (true)
            {
                var instruction = _consoleReader.ReadLine();
                var action = _commandParser.ParseCommand(instruction);
                if (action.GetType() == typeof(ExitAction))
                {
                    break;
                }
                if (action.GetType() == typeof(PlaceAction))
                {
                    Actions.Clear();
                    Actions.Add(action);
                }
                else if (Actions.Count > 0)
                {
                    Actions.Add(action);
                    if (action.GetType() == typeof(ReportAction))
                    {
                        _reportGenerator.RunReport(Actions);
                    }
                }
                
            }
        }
    }
}