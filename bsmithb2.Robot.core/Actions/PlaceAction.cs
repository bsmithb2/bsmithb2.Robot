using bsmithb2.Robot.core.Interfaces;
using bsmithb2.Robot.core.Actions;

namespace bsmithb2.Robot.core.Actions
{
    public class PlaceAction : IAction
    {
        public PlaceAction(int x, int y, string direction)
        {
            PositionX = x;
            PositionY = y;
            if (direction == "WEST")
            {
                Direction = Actions.Direction.WEST;
            }
            if (direction == "EAST")
            {
                Direction = Actions.Direction.EAST;
            }
            if (direction == "NORTH")
            {
                Direction = Actions.Direction.NORTH;
            }
            if (direction == "SOUTH")
            {
                Direction = Actions.Direction.SOUTH;
            }

        }

        public int PositionX
        {
            get;
            private set;
        }

        public int PositionY
        {
            get;
            private set;
        }

        public Actions.Direction Direction
        {
            get;
            private set;
        }
    }
}
