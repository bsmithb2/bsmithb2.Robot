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

        public List<IAction> Actions
        {
            get;
            private set;
        }

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
                }
            }

             //TODO - If Report action, then apply actions in order and report result
            //TODO - Exit?
            //TODO - A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.
            //     ----- This means that once you perform a move then you need to determine if we're off the table
            //     ----- Only valid response is PLACE



        }
    }
}