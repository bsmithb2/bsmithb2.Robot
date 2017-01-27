using bsmithb2.Robot.core.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
