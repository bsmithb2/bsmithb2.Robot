using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bsmithb2.Robot.core.Interfaces
{
    public interface ICommandParser
    {
        void ParseCommand(string commandText);
    }
}
