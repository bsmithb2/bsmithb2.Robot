using bsmithb2.Robot.core.Models;
using System.Collections.Generic;

namespace bsmithb2.Robot.core.Interfaces
{
    public interface IPositionCalculator
    {
        Position CalculatePosition(List<IAction> actions);
    }
}
