namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ComputerTests
    {
        private Computer computer;
        private Part partOne;
        private Part partTwo;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("Computer");
            partOne = new Part("One", 10);
            partTwo = new Part("Two", 20);
        }

        [Test]
        public void Constructor_ValidName_InitializesObjectSuccessfullyWithCorrectProperties()
        {
            Assert.IsNotNull(computer);
            Assert.AreEqual("Computer", computer.Name);
            Assert.IsNotNull(computer.Parts);
        }

        [Test]
        public void NameProperty_ValidName_SetsAndReturnsValue()
        {
            string expected = "Computer";
            string actual = computer.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameProperty_NullEmptyOrWhitespace_ThrowsArgumentNullException
            (string nullEmptyOrWhitespace)
        {
            Assert.Throws<ArgumentNullException>(
                () => computer = new Computer(nullEmptyOrWhitespace));
        }

        [Test]
        public void PartsProperty_EmptyCollection_ReturnsCountZero()
        {
            int expected = 0;
            int actual = computer.Parts.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PartsProperty_CollectionWithTwoElements_ReturnsCountTwo()
        {
            computer.AddPart(partOne);
            computer.AddPart(partTwo);

            int expected = 2;
            int actual = computer.Parts.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalPriceProperty_EmptyCollection_ReturnsSumZero()
        {
            decimal expected = 0m;
            decimal actual = computer.TotalPrice;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TotalPriceProperty_CollectionWithTwoElements_ReturnsTotalSumOfParts()
        {
            computer.AddPart(partOne);
            computer.AddPart(partTwo);

            decimal expected = 30m;
            decimal actual = computer.TotalPrice;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddPartMethod_PartIsNull_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => computer.AddPart(null));
        }

        [Test]
        public void AddPartMethod_ValidPart_CollectionCountIncreases()
        {
            computer.AddPart(partOne);

            int expected = 1;
            int actual = computer.Parts.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddPartMethod_ValidPart_AddsPartWithCorrectPropertiesToCollection()
        {
            computer.AddPart(partOne);

            Part addedPart = computer.GetPart("One");

            Assert.AreEqual("One", addedPart.Name);
            Assert.AreEqual(10m, addedPart.Price);
        }

        [Test]
        public void RemovePartMethod_EmptyCollection_ReturnsFalse()
        {
            bool expected = false;
            bool actual = computer.RemovePart(partOne);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemovePartMethod_UnexistingPart_ReturnsFalse()
        {
            computer.AddPart(partTwo);

            bool expected = false;
            bool actual = computer.RemovePart(partOne);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemovePartMethod_ExistingPart_ReturnsTrue()
        {
            computer.AddPart(partOne);

            bool expected = true;
            bool actual = computer.RemovePart(partOne);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemovePartMethod_ExistingPart_RemovesPartFromCollection()
        {
            computer.AddPart(partOne);
            computer.AddPart(partTwo);

            computer.RemovePart(partOne);

            object expected = null;
            object actual = computer.GetPart("One");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPartMethod_EmptyCollection_ReturnsNull()
        {
            object expected = null;
            object actual = computer.GetPart("One");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPartMethod_InvalidPartName_ReturnsNull()
        {
            computer.AddPart(partOne);

            object expected = null;
            object actual = computer.GetPart("Two");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPartMethod_ValidPartName_ReturnsPart()
        {
            computer.AddPart(partOne);

            Part expected = partOne;
            Part actual = computer.GetPart("One");

            Assert.AreEqual(expected, actual);
        }
    }
}