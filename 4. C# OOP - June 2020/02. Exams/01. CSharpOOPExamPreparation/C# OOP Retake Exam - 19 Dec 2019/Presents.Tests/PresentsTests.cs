namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class PresentsTests
    {
        private Bag testBag;
        private Present testPresent;

        [SetUp]
        public void SetUp()
        {
            testBag = new Bag();
            testPresent = new Present("testPresent", 3.14);
        }

        [Test]
        public void Constructor_Initialize_CreatesObjectWithValidState()
        {
            Assert.IsNotNull(testBag);
            Assert.IsNotNull(testBag.GetPresents());
        }

        [Test]
        public void CreateMethod_NullPresent_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => testBag.Create(null));
        }

        [Test]
        public void CreateMethod_ExistingPresent_ShouldThrowInvalidOperationException()
        {
            testBag.Create(testPresent);

            Assert.Throws<InvalidOperationException>(
                () => testBag.Create(testPresent));
        }

        [Test]
        public void CreateMethod_NonExistingPresent_ShouldAddPresentToCollection()
        {
            testBag.Create(testPresent);
            Present expected = new Present("new", 2.3);

            testBag.Create(expected);
            Present actual = testBag.GetPresents().First(p => p == expected);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateMethod_NonExistingPresent_ShouldReturnCorrectMessage()
        {   
            string expected = $"Successfully added present {testPresent.Name}.";

            string actual = testBag.Create(testPresent);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveMethod_NonExistingPresent_ShouldReturnFalse()
        {
            bool expected = false;

            bool actual = testBag.Remove(testPresent);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveMethod_ExistingPresent_ShouldReturnTrue()
        {
            bool expected = true;
            testBag.Create(testPresent);

            bool actual = testBag.Remove(testPresent);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveMethod_ExistingPresent_ShouldRemoveObjectFromCollection()
        {
            testBag.Create(testPresent);

            testBag.Remove(testPresent);

            Present removedPresent = testBag.GetPresents().FirstOrDefault(p => p == testPresent);

            Assert.AreEqual(null, removedPresent);
        }

        [Test]
        public void GetPresentWithLeastMagicMethod_NonEmptyCollection_ShouldReturnPresentWithLeastMagic()
        {
            testBag.Create(testPresent);
            testBag.Create(new Present("biggerMagic", 5));
            Present expected = testPresent;

            Present actual = testBag.GetPresentWithLeastMagic();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentMethod_NonExistingName_ShouldReturnNull()
        {
            Present expected = null;

            Present actual = testBag.GetPresent("invalid");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentMethod_ExistingName_ShouldReturnPresentWithThatName()
        {
            testBag.Create(testPresent);
            Present expected = testPresent;

            Present actual = testBag.GetPresent("testPresent");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPresentsMethod_CollectionWithTwoPresents_ShouldReturnCountTwo()
        {
            testBag.Create(testPresent);
            testBag.Create(new Present("another", 4.3));

            Assert.AreEqual(2, testBag.GetPresents().Count);
        }

        [Test]
        public void GetPresentsMethod_CollectionWithTwoPresents_ShouldReturnCorrectPresents()
        {
            testBag.Create(testPresent);
            testBag.Create(new Present("another", 4.3));

            List<Present> addedPresents = testBag.GetPresents().Select(p => p).ToList();

            Assert.AreEqual("testPresent", addedPresents[0].Name);
            Assert.AreEqual(3.14, addedPresents[0].Magic);
            Assert.AreEqual("another", addedPresents[1].Name);
            Assert.AreEqual(4.3, addedPresents[1].Magic);
        }
    }
}
