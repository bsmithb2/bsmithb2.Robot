using bsmithb2.Robot.core.Actions;

namespace bsmithb2.Robot.core.Models
{
    public class Position
    {
        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction; 
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public Direction Direction
        {
            get;
            private set;
        }
    }
}
