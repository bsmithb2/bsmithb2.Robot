using bsmithb2.Robot.core;
using bsmithb2.Robot.core.Actions;
using bsmithb2.Robot.core.Interfaces;
using bsmithb2.Robot.core.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class ReportGeneratorTests
    {
        [Test]
        public void RunReport_ShouldAcceptListOfActionsAndPassThemToPositionCalculator()
        {
            var positionCalculator = Substitute.For<IPositionCalculator>();
            var reportGenerator = new ReportGenerator(positionCalculator);

            var actions = new List<IAction> { new PlaceAction(1, 1, "WEST"), };
            reportGenerator.RunReport(actions);

            positionCalculator.Received(1).CalculatePosition(actions);
        }

        [Test]
        public void RunReport_ShouldTakePositionFromCalculatorAndFormatResult()
        {
            var positionCalculator = Substitute.For<IPositionCalculator>();
            positionCalculator.CalculatePosition(null).ReturnsForAnyArgs(new Position(0, 1, Direction.NORTH));
            var reportGenerator = new ReportGenerator(positionCalculator);

            var actions = new List<IAction> { };
            var result = reportGenerator.RunReport(actions);

            Assert.AreEqual("0,1,NORTH", result);
        }
    }
}
