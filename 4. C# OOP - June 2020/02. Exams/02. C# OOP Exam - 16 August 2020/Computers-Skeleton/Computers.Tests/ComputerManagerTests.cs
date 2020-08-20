using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    [TestFixture]
    public class ComputerManagerTests
    {
        private ComputerManager computerManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            computer = new Computer("testManufacturer", "testModel", 1);
        }

        [Test]
        public void Constructor_Initialize_ShouldCreateObjectWithValidState()
        {
            Assert.IsNotNull(computerManager);
            Assert.IsNotNull(computerManager.Computers);
        }

        [Test]
        public void ComputersProperty_EmptyCollection_ShouldReturnCollectionCountZero()
        {
            Assert.AreEqual(0, computerManager.Computers.Count);
        }

        [Test]
        public void ComputersProperty_CollectionOneElement_ShouldReturnCollectionCountOne()
        {
            computerManager.AddComputer(computer);

            Assert.AreEqual(1, computerManager.Computers.Count);
        }

        [Test]
        public void CountProperty_EmptyCollection_ShouldReturnCountZero()
        {
            Assert.AreEqual(0, computerManager.Count);
        }

        [Test]
        public void CountProperty_CollectionOneElement_ShouldReturnCountOne()
        {
            computerManager.AddComputer(computer);

            Assert.AreEqual(1, computerManager.Count);
        }

        [Test]
        public void AddComputerMethod_NullComputer_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.AddComputer(null));
        }

        [Test]
        public void AddComputerMethod_ExistingManufacturerAndModel_ShouldThrowArgumentException()
        {
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(
                () => computerManager.AddComputer(new Computer("testManufacturer", "testModel", 5)));
        }

        [Test]
        public void AddComputerMethod_ValidComputer_ShouldAddComputerWithCorrectProperties()
        {
            computerManager.AddComputer(computer);

            Computer addedComputer = computerManager.Computers.First(c => c == computer);

            Assert.AreEqual(computer.Manufacturer, addedComputer.Manufacturer);
            Assert.AreEqual(computer.Model, addedComputer.Model);
            Assert.AreEqual(computer.Price, addedComputer.Price);
        }

        [Test]
        public void AddComputerMethod_ValidComputer_ShouldIncreaseCount()
        {
            computerManager.AddComputer(computer);

            Assert.AreEqual(1, computerManager.Count);
        }

        [Test]
        public void RemoveComputerMethod_ExistingManufaturerAndModel_ShouldReturnComputerWithThoseProperties()
        {
            computerManager.AddComputer(computer);

            Computer removedComputer = computerManager.RemoveComputer("testManufacturer", "testModel");

            Assert.AreEqual(computer.Manufacturer, removedComputer.Manufacturer);
            Assert.AreEqual(computer.Model, removedComputer.Model);
            Assert.AreEqual(computer.Price, removedComputer.Price);
        }

        [Test]
        public void RemoveComputerMethod_ExistingManufaturerAndModel_ShouldDecreaseCount()
        {
            computerManager.AddComputer(computer);

            Computer removedComputer = computerManager.RemoveComputer("testManufacturer", "testModel");

            Assert.AreEqual(0, computerManager.Count);
        }

        [Test]
        public void RemoveComputerMethod_NonExistingManufaturerAndModel_ShouldThrowArgumentException()
        {
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(
                () => computerManager.RemoveComputer("invalid1", "invalid2"));
        }

        [Test]
        public void GetComputerMethod_NullManufacturer_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer(null, "model"));
        }

        [Test]
        public void GetComputerMethod_NullModel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputer("manufacturer", null));
        }

        [Test]
        public void GetComputerMethod_NonExistingManufaturerAndModel_ShouldThrowArgumentException()
        {
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(
                () => computerManager.GetComputer("invalid1", "invalid2"));
        }

        [Test]
        public void GetComputerMethod_ExistingManufaturerAndModel_ShouldReturnComputerWithThoseProperties()
        {
            computerManager.AddComputer(computer);

            Computer receivedComputer = computerManager.GetComputer("testManufacturer", "testModel");

            Assert.AreEqual(computer.Manufacturer, receivedComputer.Manufacturer);
            Assert.AreEqual(computer.Model, receivedComputer.Model);
            Assert.AreEqual(computer.Price, receivedComputer.Price);
        }

        [Test]
        public void GetComputersByManufacturerMethod_NullManufacturer_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturerMethod_ExistingManufacturer_ShouldReturnNewCollectionWithCountTwo()
        {
            computerManager.AddComputer(computer);
            computerManager.AddComputer(new Computer("testManufacturer", "testModel2", 2));
            computerManager.AddComputer(new Computer("otherManufacturer", "testModel3", 3));

            List<Computer> filteredComputers = computerManager.GetComputersByManufacturer("testManufacturer").ToList();

            Assert.AreEqual(2, filteredComputers.Count);
        }

        [Test]
        public void GetComputersByManufacturerMethod_ExistingManufacturer_ShouldReturnNewCollectionWithCorrectComputerItems()
        {
            Computer computer1 = new Computer("testManufacturer", "testModel2", 2);
            Computer computer2 = new Computer("otherManufacturer", "testModel3", 3);
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);

            List<Computer> filteredComputers = computerManager.GetComputersByManufacturer("testManufacturer").ToList();

            Assert.IsTrue(filteredComputers.Contains(computer));
            Assert.IsTrue(filteredComputers.Contains(computer1));
        }
    }
}