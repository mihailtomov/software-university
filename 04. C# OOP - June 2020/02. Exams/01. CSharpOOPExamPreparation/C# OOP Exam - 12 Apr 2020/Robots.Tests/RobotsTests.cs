namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robotManager = new RobotManager(5);
        }

        [Test]
        public void Constructor_ValidCapacity_ShouldCreateObjectWithValidState()
        {
            Assert.IsNotNull(robotManager);
            Assert.AreEqual(0, robotManager.Count);
            Assert.AreEqual(5, robotManager.Capacity);
        }

        [TestCase(0)]
        [TestCase(3)]
        public void CapacityProperty_ZeroOrPositiveValue_ShouldSetAndReturnValue
            (int zeroOrPositiveValue)
        {
            robotManager = new RobotManager(zeroOrPositiveValue);

            int expected = zeroOrPositiveValue;
            int actual = robotManager.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CapacityProperty_NegativeValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => robotManager = new RobotManager(-1));
        }

        [Test]
        public void CountProperty_EmptyCollection_ShouldReturnZero()
        {
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void CountProperty_CollectionWithTwoElements_ShouldReturnTwo()
        {
            robotManager.Add(new Robot("robot1", 10));
            robotManager.Add(new Robot("robot2", 20));

            Assert.AreEqual(2, robotManager.Count);
        }

        [Test]
        public void AddMethod_RobotWithSameName_ShouldThrowInvalidOperationException()
        {
            robotManager.Add(new Robot("robot1", 10));
            robotManager.Add(new Robot("robot2", 20));

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(new Robot("robot1", 30)));
        }

        [Test]
        public void AddMethod_OverCapacity_ShouldThrowInvalidOperationException()
        {
            for (int i = 0; i < 5; i++)
            {
                robotManager.Add(new Robot($"{i}#", i));
            }

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(new Robot("robot1", 30)));
        }

        [Test]
        public void AddMethod_AddSuccessfully_ShouldIncreaseCount()
        {
            robotManager.Add(new Robot("robot1", 10));

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RemoveMethod_NonExistingName_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => robotManager.Remove("invalid"));
        }

        [Test]
        public void RemoveMethod_ExistingName_ShouldDecreaseCount()
        {
            robotManager.Add(new Robot("robot1", 10));

            robotManager.Remove("robot1");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void WorkMethod_NonExistingName_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("invalid", "test", 5));
        }

        [Test]
        public void WorkMethod_ExistingNameNotEnoughBattery_ShouldThrowInvalidOperationException()
        {
            robotManager.Add(new Robot("robot1", 10));

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("robot1", "test", 15));
        }

        [Test]
        public void WorkMethod_ExistingNameEnoughBattery_ShouldDecreaseRobotBattery()
        {
            Robot robot = new Robot("robot1", 10);
            robotManager.Add(robot);

            robotManager.Work("robot1", "test", 5);

            Assert.AreEqual(5, robot.Battery);
        }

        [Test]
        public void ChargeMethod_NonExistingName_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => robotManager.Charge("invalid"));
        }

        [Test]
        public void ChargeMethod_ExistingName_ShouldSetBatteryToMaximumBattery()
        {
            Robot robot = new Robot("robot1", 10);
            robotManager.Add(robot);
            robotManager.Work("robot1", "test", 5);

            robotManager.Charge("robot1");

            Assert.AreEqual(robot.MaximumBattery, robot.Battery);
        }
    }
}
