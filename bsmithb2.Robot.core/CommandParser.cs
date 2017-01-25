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

                if(firstArgValue < 0 || firstArgValue > 4)
                {
                    return null;
                }
                return new PlaceAction();
            }
            else
            {
                return null;
            }
        }
    }
}
