using bsmithb2.Robot.core;
using bsmithb2.Robot.Tests.Containers;
using NSubstitute;
using NUnit.Framework;

namespace bsmithb2.Robot.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Program_Should_Call_TestContainers_IApplication()
        {
            //Arrange
            var testContainer = new TestContainer();
            Program.Container = testContainer.Configure();

            //Act
            Program.Main(null);

            //Assert
            testContainer.Application.Received(1).Run();
        }
    }
}
