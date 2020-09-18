using DatabaseProblem;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2, 3);
        }

        [Test]
        public void Constructor_ThreeElements_CountShouldReturnThree()
        {
            Assert.That(database.Count, Is.EqualTo(3));
        }

        [Test]
        public void Constructor_ZeroElements_CountShouldReturnZero()
        {
            database = new Database();

            Assert.That(database.Count, Is.EqualTo(0));
        }


        [Test]
        public void Add_AddElementOutsideRange_ShouldThrowException()
        {
            database = new Database(new int[16]);

            Assert.That(() => database.Add(1), Throws.InvalidOperationException
                .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_AddElementWithinRange_ShouldAddElementToArray()
        {
            database.Add(1);

            Assert.That(() => database.Fetch()[3], Is.EqualTo(1));
        }

        [Test]
        public void Add_AddElementWithinRange_ShouldIncreaseCount()
        {
            database.Add(1);

            Assert.That(database.Count, Is.EqualTo(4));
        }

        [Test]
        public void Remove_EmptyArray_ShouldThrowException()
        {
            database = new Database();

            Assert.That(() => database.Remove(), Throws.InvalidOperationException
                .With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Remove_NonEmptyArray_ShouldRemoveLastElement()
        {
            int removedEl = database.Fetch()[2];

            database.Remove();

            Assert.That(database.Fetch(), !Contains.Item(removedEl));
        }

        [Test]
        public void Remove_NonEmptyArray_ShouldDecreaseCount()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void Fetch_EmptyArray_ShouldReturnEmptyArray()
        {
            database = new Database();

            int[] array = database.Fetch();

            Assert.That(array.Length, Is.EqualTo(0));
        }

        [Test]
        public void Fetch_NonEmptyArray_ShouldReturnArray()
        {
            int[] expectedArray = new int[] { 1, 2, 3 };

            int[] actualArray = database.Fetch();

            Assert.That(expectedArray, Is.EquivalentTo(actualArray));
        }
    }
}