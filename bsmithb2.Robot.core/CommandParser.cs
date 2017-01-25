using bsmithb2.Robot.core.Actions;
using bsmithb2.Robot.core.Interfaces;

namespace bsmithb2.Robot.core
{
    public class CommandParser : ICommandParser
    {
        public IAction ParseCommand(string commandText)
        {
            if (commandText.StartsWith("PLACE "))
            {
                var args = commandText.Replace("PLACE ", "").Split(',');
                if(args.Length != 3)
                {
                    return null;
                }
                var firstArg = args[0];
                int firstArgValue;
                if(!int.TryParse(firstArg, out firstArgValue))
                {
                    return null;
                }
                
                if (firstArgValue < 0 || firstArgValue > 4)
                {
                    return null;
                }

                var secondArg = args[1];
                int secondArgValue;
                if (!int.TryParse(secondArg, out secondArgValue))
                {
                    return null;
                }

                if (secondArgValue < 0 || secondArgValue > 4)
                {
                    return null;
                }

                var positionArg = args[2];
                if(positionArg != "NORTH" 
                    && positionArg != "SOUTH"
                    && positionArg != "EAST"
                    && positionArg != "WEST")
                {
                    return null;
                }

                return new PlaceAction(firstArgValue, secondArgValue, positionArg);
            }
            else if(commandText == "MOVE")
            {
                return new MoveAction();
            }
            else if (commandText == "LEFT")
            {
                return new LeftAction();
            }
            else if (commandText == "RIGHT")
            {
                return new RightAction();
            }
            else if (commandText == "REPORT")
            {
                return new ReportAction();
            }
            else
            {
                return null;
            }
        }
    }
}
