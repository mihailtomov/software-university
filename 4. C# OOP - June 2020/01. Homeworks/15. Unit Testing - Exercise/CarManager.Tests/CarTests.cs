using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car validCar;

        [SetUp]
        public void Setup()
        {
            validCar = new Car("Make", "Model", 5, 50);
        }

        [Test]
        public void Constructor_ValidData_ShouldSuccessfullyInitiliazeCarObject()
        {
            Assert.IsNotNull(validCar);
        }

        [Test]
        public void Constructor_ValidData_ShouldInitiliazeCarWithZeroFuelAmount()
        {
            double expected = 0;
            double actual = validCar.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Constructor_InvalidData_ShouldThrowArgumentException()
        {
            Car invalidCar;

            Assert.Throws<ArgumentException>(
                () => invalidCar = new Car("", "gf", 1, 4));
        }

        [Test]
        public void Make_ValidData_ShouldSetAndReturnMakeValue()
        {
            string expected = "Make";
            string actual = validCar.Make;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Make_NullOrEmpty_ShouldThrowArgumentException(string nullOrEmpty)
        {
            Car invalidMake;

            Assert.Throws<ArgumentException>(
                () => invalidMake = new Car(nullOrEmpty, "test", 1, 1));
        }

        [Test]
        public void Model_ValidData_ShouldSetAndReturnModelValue()
        {
            string expected = "Model";
            string actual = validCar.Model;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Model_NullOrEmpty_ShouldThrowArgumentException(string nullOrEmpty)
        {
            Car invalidModel;

            Assert.Throws<ArgumentException>(
                () => invalidModel = new Car("test", nullOrEmpty, 1, 1));
        }

        [Test]
        public void FuelConsumption_ValidData_ShouldSetAndReturnFuelConsumptionValue()
        {
            double expected = 5;
            double actual = validCar.FuelConsumption;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FuelConsumption_ZeroNumber_ShouldThrowArgumentException()
        {
            Car invalidFuelConsumption;

            Assert.Throws<ArgumentException>(
                () => invalidFuelConsumption = new Car("test", "test1", 0, 1));
        }

        [Test]
        public void FuelConsumption_NegativeNumber_ShouldThrowArgumentException()
        {
            Car invalidFuelConsumption;

            Assert.Throws<ArgumentException>(
                () => invalidFuelConsumption = new Car("test", "test1", -1, 1));
        }

        [Test]
        public void FuelCapacity_ValidData_ShouldSetAndReturnFuelCapacityValue()
        {
            double expected = 50;
            double actual = validCar.FuelCapacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FuelCapacity_ZeroNumber_ShouldThrowArgumentException()
        {
            Car invalidFuelCapacity;

            Assert.Throws<ArgumentException>(
                () => invalidFuelCapacity = new Car("test", "test1", 1, 0));
        }

        [Test]
        public void FuelCapacity_NegativeNumber_ShouldThrowArgumentException()
        {
            Car invalidFuelCapacity;

            Assert.Throws<ArgumentException>(
                () => invalidFuelCapacity = new Car("test", "test1", 1, -1));
        }

        [Test]
        public void Refuel_ZeroNumber_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => validCar.Refuel(0));
        }

        [Test]
        public void Refuel_NegativeNumber_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => validCar.Refuel(-1));
        }

        [Test]
        public void Refuel_ValidData_ShouldIncreaseFuelAmount()
        {
            validCar.Refuel(30);

            double expected = 30;
            double actual = validCar.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Refuel_AmountLargerThanCapacity_ShouldAddToMaximumCapacity()
        {
            validCar.Refuel(60);

            double expected = 50;
            double actual = validCar.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Drive_InsufficientFuelAmount_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => validCar.Drive(100));
        }

        [Test]
        public void Drive_SufficientFuelAmount_ShouldDecreaseFuelAmount()
        {
            validCar.Refuel(50);

            validCar.Drive(500);

            double expected = 25;
            double actual = validCar.FuelAmount;

            Assert.AreEqual(expected, actual);
        }
    }
}