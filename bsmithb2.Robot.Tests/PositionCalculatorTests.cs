using bsmithb2.Robot.core;
using bsmithb2.Robot.core.Actions;
using bsmithb2.Robot.core.Interfaces;
using bsmithb2.Robot.core.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class PositionCalculatorTests
    {
        [Test]
        public void CalculatePosition_PlaceInCornerValid()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0,0, "NORTH") };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.NORTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,NORTH
        /// MOVE
        /// REPORT
        /// Output: 0,1,NORTH
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerMove_ValidNorth()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "NORTH"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 1, Direction.NORTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,EAST
        /// MOVE
        /// REPORT
        /// Output: 1,0,EAST
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerMove_ValidEast()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "EAST"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(1, 0, Direction.EAST);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 4,4,WEST
        /// MOVE
        /// REPORT
        /// Output: 3,4,WEST
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerMove_ValidWest()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(4, 4, "WEST"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(3, 4, Direction.WEST);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,4,SOUTH
        /// MOVE
        /// REPORT
        /// Output: 0,3,SOUTH
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerMove_ValidSouth()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 4, "SOUTH"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 3, Direction.SOUTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,4,SOUTH
        /// MOVE
        /// REPORT
        /// Output: 0,3,SOUTH
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCorner2Moves_ValidSouth()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 4, "SOUTH"), new MoveAction(), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 2, Direction.SOUTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }
        /// <summary>
        /// PLACE 0,0,SOUTH
        /// LEFT
        /// REPORT
        /// Output: 0,0,WEST
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingSouth_ThenLeft_East()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "SOUTH"), new LeftAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.EAST);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,EAST
        /// LEFT
        /// REPORT
        /// Output: 0,0,NORTH
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingEast_ThenLeft_North()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "EAST"), new LeftAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.NORTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,NORTH
        /// LEFT
        /// REPORT
        /// Output: 0,0,WEST
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingNorth_ThenLeft_West()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "NORTH"), new LeftAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.WEST);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,WEST
        /// LEFT
        /// REPORT
        /// Output: 0,0,SOUTH
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingWest_ThenLeft_South()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "WEST"), new LeftAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.SOUTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,WEST
        /// RIGHT
        /// REPORT
        /// Output: 0,0,NORTH
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingWest_ThenRight_North()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "WEST"), new RightAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.NORTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,NORTH
        /// RIGHT
        /// REPORT
        /// Output: 0,0,EAST
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingNorth_ThenRight_East()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "NORTH"), new RightAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.EAST);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,EAST
        /// RIGHT
        /// REPORT
        /// Output: 0,0,SOUTH
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingEast_ThenRight_South()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "EAST"), new RightAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.SOUTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,SOUTH
        /// RIGHT
        /// REPORT
        /// Output: 0,0,WEST
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceInCornerFacingSouth_ThenRight_West()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "SOUTH"), new RightAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);
            var expectedPosition = new Position(0, 0, Direction.WEST);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 0,0,SOUTH
        /// MOVE
        /// REPORT
        /// Output: {null}
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceAndMoveInInvalidPosition_ReturnNull()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "SOUTH"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);

            Assert.IsNull(actualPosition);
        }

        /// <summary>
        /// PLACE 0,1,SOUTH
        /// MOVE
        /// MOVE
        /// REPORT
        /// Output: {null}
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceAndMoveTwiceToInvalidPosition_ReturnNull()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 1, "SOUTH"), new MoveAction(), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);

            Assert.IsNull(actualPosition);
        }

        /// <summary>
        /// PLACE 4,4,EAST
        /// MOVE
        /// REPORT
        /// Output: {null}
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceAndMoveInInvalidPositionEast_ReturnNull()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(4, 4, "EAST"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);

            Assert.IsNull(actualPosition);
        }

        /// <summary>
        /// PLACE 4,4,NORTH
        /// MOVE
        /// REPORT
        /// Output: {null}
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceAndMoveInInvalidPositionNorth_ReturnNull()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(4, 4, "NORTH"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);

            Assert.IsNull(actualPosition);
        }

        /// <summary>
        /// PLACE 0,0,WEST
        /// MOVE
        /// REPORT
        /// Output: {null}
        /// </summary>
        [Test]
        public void CalculatePosition_PlaceAndMoveInInvalidPositionWEST_ReturnNull()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "WEST"), new MoveAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);

            Assert.IsNull(actualPosition);
        }

        /// <summary>
        /// PLACE 0,0,NORTH
        /// LEFT
        /// REPORT
        /// Output: 0,0,WEST
        /// </summary>
        [Test]
        public void CalculatePosition_North_ThenLeft_ReturnsPosition()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(0, 0, "NORTH"), new LeftAction(), new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);

            var expectedPosition = new Position(0, 0, Direction.WEST);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }

        /// <summary>
        /// PLACE 1,2,EAST
        /// MOVE
        /// MOVE
        /// LEFT
        /// MOVE
        /// REPORT
        /// Output: 3,3,NORTH
        /// </summary>
        [Test]
        public void CalculatePosition_East_ThenComplex_ReturnsPosition()
        {
            var positionCalculator = new PositionCalculator();
            var actions = new List<IAction> { new PlaceAction(1, 2, "EAST"),
                new MoveAction(),
                new MoveAction(),
                new LeftAction(),
                new MoveAction(),
                new ReportAction() };
            var actualPosition = positionCalculator.CalculatePosition(actions);

            var expectedPosition = new Position(3, 3, Direction.NORTH);

            Assert.AreEqual(expectedPosition.X, actualPosition.X);
            Assert.AreEqual(expectedPosition.Y, actualPosition.Y);
            Assert.AreEqual(expectedPosition.Direction, actualPosition.Direction);
        }
    }
}
