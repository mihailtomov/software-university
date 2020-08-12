using DatabaseExtended;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person personOne;
        private Person personTwo;
        private Person[] persons;
        private ExtendedDatabase emptyDatabase;
        private ExtendedDatabase nonEmptyDatabase;

        [SetUp]
        public void Setup()
        {
            personOne = new Person(100, "Teodor");
            personTwo = new Person(200, "George");
            persons = new Person[2] { personOne, personTwo };
            emptyDatabase = new ExtendedDatabase();
            nonEmptyDatabase = new ExtendedDatabase(persons);
        }

        [Test]
        public void Constructor_Empty_CountShouldReturnZero()
        {
            Assert.That(emptyDatabase.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_TwoElements_CountShouldReturnTwo()
        {
            Assert.That(nonEmptyDatabase.Count, Is.EqualTo(2));
        }

        [Test]
        public void Constructor_SeventeenElements_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => emptyDatabase = new ExtendedDatabase(new Person[17]));
        }

        [Test]
        public void Constructor_OnePerson_AddedToDatabase()
        {
            emptyDatabase = new ExtendedDatabase(personOne);

            Assert.That(() => emptyDatabase.FindById(100), Is.EqualTo(personOne));
        }

        [Test]
        public void Constructor_OnePerson_AddedCorrectProperties()
        {
            emptyDatabase = new ExtendedDatabase(personOne);

            Person actualRes = emptyDatabase.FindById(100);

            Assert.That(actualRes.Id, Is.EqualTo(100));
            Assert.That(actualRes.UserName, Is.EqualTo("Teodor"));
        }

        [Test]
        public void Add_UniquePersonArrayWithSpace_CountShouldIncrease()
        {
            emptyDatabase.Add(personOne);

            Assert.That(emptyDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_UniquePersonArrayWithSpace_ShouldReturnPerson()
        {
            Person person = new Person(300, "Peter");

            nonEmptyDatabase.Add(person);

            Assert.That(() => nonEmptyDatabase.FindById(300), Is.EqualTo(person));
        }

        [Test]
        public void Add_UniquePersonArrayWithSpace_AddedCorrectProperties()
        {
            Person person = new Person(300, "Peter");
            nonEmptyDatabase.Add(person);

            Person actualRes = nonEmptyDatabase.FindById(300);

            Assert.That(actualRes.Id, Is.EqualTo(300));
            Assert.That(actualRes.UserName, Is.EqualTo("Peter"));
        }

        [Test]
        public void Add_UniquePersonArrayWithoutSpace_ShouldThrowException()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i + 1, $"A{i}");
            }

            emptyDatabase = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(
                () => emptyDatabase.Add(personOne));
        }

        [Test]
        public void Add_PersonSameUsername_ShouldThrowException()
        {
            Person sameUsername = new Person(123, "Teodor");

            emptyDatabase = new ExtendedDatabase(sameUsername);

            Assert.Throws<InvalidOperationException>(
                () => emptyDatabase.Add(personOne));
        }

        [Test]
        public void Add_PersonSameId_ShouldThrowException()
        {
            Person sameId = new Person(100, "Alexander");

            emptyDatabase = new ExtendedDatabase(sameId);

            Assert.Throws<InvalidOperationException>(
                () => emptyDatabase.Add(personOne));
        }

        [Test]
        public void Remove_EmptyDatabase_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => emptyDatabase.Remove());
        }

        [Test]
        public void Remove_NonEmptyDatabase_CountShouldDecrease()
        {
            nonEmptyDatabase.Remove();

            Assert.That(nonEmptyDatabase.Count, Is.EqualTo(1));
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_NullOrEmptyArgument_ShouldThrowException
            (string username)
        {
            Assert.Throws<ArgumentNullException>(
                () => nonEmptyDatabase.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_InvalidUsername_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => nonEmptyDatabase.FindByUsername("Elena"));
        }

        [Test]
        public void FindByUsername_ValidUsername_ShouldReturnCorrectPerson()
        {
            Person actualRes = nonEmptyDatabase.FindByUsername("Teodor");

            Assert.That(actualRes.Id, Is.EqualTo(100));
            Assert.That(actualRes.UserName, Is.EqualTo("Teodor"));
        }

        [Test]
        public void FindById_IdNegativeNumber_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => nonEmptyDatabase.FindById(-12));
        }

        [Test]
        public void FindById_InvalidId_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => nonEmptyDatabase.FindById(2));
        }

        [Test]
        public void FindById_ValidId_ShouldReturnCorrectPerson()
        {
            Person actualRes = nonEmptyDatabase.FindById(100);

            Assert.That(actualRes.Id, Is.EqualTo(100));
            Assert.That(actualRes.UserName, Is.EqualTo("Teodor"));
        }
    }
}