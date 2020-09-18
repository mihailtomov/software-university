namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium testAquarium;

        [SetUp]
        public void SetUp()
        {
            testAquarium = new Aquarium("testName", 10);
        }

        [Test]
        public void Constructor_ValidData_ShouldCreateObjectWithValidState()
        {
            Assert.IsNotNull(testAquarium);
            Assert.AreEqual("testName", testAquarium.Name);
            Assert.AreEqual(10, testAquarium.Capacity);
            Assert.AreEqual(0, testAquarium.Count);
        }

        [Test]
        public void NameProperty_ValidName_ShouldSetAndReturnName()
        {
            string expected = "testName";
            string actual = testAquarium.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameProperty_NullOrEmpty_ShouldThrowArgumentNullException
            (string nullOrEmpty)
        {
            Assert.Throws<ArgumentNullException>(
                () => testAquarium = new Aquarium(nullOrEmpty, 20));
        }

        [TestCase(0)]
        [TestCase(1)]
        public void CapacityProperty_ZeroOrPositiveValue_ShouldSetAndReturnValue
            (int zeroOrPositive)
        {
            testAquarium = new Aquarium("test", zeroOrPositive);

            int expected = zeroOrPositive;
            int actual = testAquarium.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CapacityProperty_NegativeValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => testAquarium = new Aquarium("test", -1));
        }

        [Test]
        public void CountProperty_EmptyCollection_ShouldReturnZero()
        {
            Assert.AreEqual(0, testAquarium.Count);
        }

        [Test]
        public void CountProperty_CollectionWithTwoElements_ShouldReturnTwo()
        {
            testAquarium.Add(new Fish("fish1"));
            testAquarium.Add(new Fish("fish2"));

            Assert.AreEqual(2, testAquarium.Count);
        }

        [Test]
        public void AddMethod_AddFishEnoughCapacity_ShouldIncreaseCount()
        {
            testAquarium.Add(new Fish("fish1"));

            Assert.AreEqual(1, testAquarium.Count);
        }

        [Test]
        public void AddMethod_AddFishNotEnoughCapacity_ShouldThrowInvalidOperationException()
        {
            testAquarium = new Aquarium("test", 1);

            testAquarium.Add(new Fish("fish1"));

            Assert.Throws<InvalidOperationException>(
                () => testAquarium.Add(new Fish("fish2")));
        }

        [Test]
        public void RemoveFishMethod_NonExistingName_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => testAquarium.RemoveFish("invalid"));
        }

        [Test]
        public void RemoveFishMethod_ExistingName_ShouldDecreaseCount()
        {
            testAquarium.Add(new Fish("fish1"));

            testAquarium.RemoveFish("fish1");

            Assert.AreEqual(0, testAquarium.Count);
        }

        [Test]
        public void SellFishMethod_NonExistingName_ShouldThrowInvalidOperationException()
        {
            testAquarium.Add(new Fish("fish1"));

            Assert.Throws<InvalidOperationException>(
                () => testAquarium.SellFish("invalid"));
        }

        [Test]
        public void SellFishMethod_ExistingName_ShouldSetFishAvailablePropertyToFalse()
        {
            testAquarium.Add(new Fish("fish1"));

            Fish soldFish = testAquarium.SellFish("fish1");

            Assert.AreEqual(false, soldFish.Available);
        }

        [Test]
        public void SellFishMethod_ExistingName_ShouldReturnFishWithThatName()
        {
            testAquarium.Add(new Fish("fish1"));

            Fish soldFish = testAquarium.SellFish("fish1");

            Assert.AreEqual("fish1", soldFish.Name);
        }

        [Test]
        public void ReportMethod_EmptyCollection_ShouldReturnMessageWithNoFishNames()
        {
            string expected = "Fish available at testName: ";
            string actual = testAquarium.Report();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReportMethod_CollectionWithTwoFishes_ShouldReturnMessageWithFishesNames()
        {
            testAquarium.Add(new Fish("fish1"));
            testAquarium.Add(new Fish("fish2"));

            string expected = "Fish available at testName: fish1, fish2";
            string actual = testAquarium.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}
