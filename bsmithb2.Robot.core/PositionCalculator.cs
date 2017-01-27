using System;
using System.Collections.Generic;
using bsmithb2.Robot.core.Interfaces;
using bsmithb2.Robot.core.Models;
using bsmithb2.Robot.core.Actions;

namespace bsmithb2.Robot.core
{
    public class PositionCalculator : IPositionCalculator
    {
        public Position CalculatePosition(List<IAction> actions)
        {
            Position position = null;
            foreach(var action in actions)
            {
                if(action is PlaceAction)
                {
                    var placeAction = ((PlaceAction)action);
                    position = new Position(placeAction.PositionX, placeAction.PositionY, placeAction.Direction);
                }
                if (position != null)
                {
                    if (action is MoveAction)
                    {
                        if(position.Direction == Direction.NORTH)
                        {
                            position = new Position(position.X, position.Y + 1, position.Direction);
                        }
                        if (position.Direction == Direction.EAST)
                        {
                            position = new Position(position.X + 1, position.Y, position.Direction);
                        }
                        if (position.Direction == Direction.WEST)
                        {
                            position = new Position(position.X - 1, position.Y, position.Direction);
                        }
                        if (position.Direction == Direction.SOUTH)
                        {
                            position = new Position(position.X, position.Y - 1, position.Direction);
                        }
                        if(position.X < 0 || position.Y < 0 || position.X > 4 || position.Y > 4)
                        {
                            position = null;
                        }
                    }
                    if(action is LeftAction)
                    {
                        if (position.Direction == Direction.SOUTH)
                        {
                            position = new Position(position.X, position.Y, Direction.EAST);
                        }
                        else if (position.Direction == Direction.EAST)
                        {
                            position = new Position(position.X, position.Y, Direction.NORTH);
                        }
                        else if (position.Direction == Direction.NORTH)
                        {
                            position = new Position(position.X, position.Y, Direction.WEST);
                        }
                        else if (position.Direction == Direction.WEST)
                        {
                            position = new Position(position.X, position.Y, Direction.SOUTH);
                        }
                    }

                    if (action is RightAction)
                    {
                        if (position.Direction == Direction.SOUTH)
                        {
                            position = new Position(position.X, position.Y, Direction.WEST);
                        }
                        else if (position.Direction == Direction.EAST)
                        {
                            position = new Position(position.X, position.Y, Direction.SOUTH);
                        }
                        else if (position.Direction == Direction.NORTH)
                        {
                            position = new Position(position.X, position.Y, Direction.EAST);
                        }
                        else if (position.Direction == Direction.WEST)
                        {
                            position = new Position(position.X, position.Y, Direction.NORTH);
                        }
                    }
                }
            }

            return position;
        }
    }
}
