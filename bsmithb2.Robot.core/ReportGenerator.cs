using bsmithb2.Robot.core.Interfaces;
using System.Collections.Generic;

namespace bsmithb2.Robot.core
{
    public class ReportGenerator : IReportGenerator
    {
        private IPositionCalculator _positionCalculator;

        public ReportGenerator(IPositionCalculator positionCalculator)
        {
            _positionCalculator = positionCalculator;
        }

        public string RunReport(List<IAction> actions)
        {
            var position = _positionCalculator.CalculatePosition(actions);
            if(position == null)
            {
                return string.Empty;
            }
            return string.Format("{0},{1},{2}", position.X, position.Y, position.Direction.ToString());
        }
    }
}
