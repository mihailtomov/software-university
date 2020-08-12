using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Constructor_CreateObject_InitializesObjectWithPrivateWarriorList()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void CountProperty_SuccessfullyCreatedObject_ReturnsZero()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void CountProperty_ListWithOneWarrior_ReturnsOne()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollMethod_WarriorsWithSameName_ThrowsInvalidOperationException()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(new Warrior("Peter", 10, 60)));
        }

        [Test]
        public void EnrollMethod_WarriorsWithDifferentNames_AddsWarriorsToList()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));
            arena.Enroll(new Warrior("George", 20, 50));

            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void FightMethod_AttackerInvalidDefenderValid_ThrowsInvalidOperationException()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));
            arena.Enroll(new Warrior("George", 20, 50));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("InvalidAttacker", "George"));
        }

        [Test]
        public void FightMethod_AttackerInvalidDefenderValid_ThrowsCorrectMessage()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));
            arena.Enroll(new Warrior("George", 20, 50));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("InvalidAttacker", "George"),
                "There is no fighter with name InvalidAttacker enrolled for the fights!");
        }

        [Test]
        public void FightMethod_AttackerValidDefenderInvalid_ThrowsInvalidOperationException()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));
            arena.Enroll(new Warrior("George", 20, 50));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Peter", "InvalidDefender"));
        }

        [Test]
        public void FightMethod_AttackerValidDefenderInvalid_ThrowsCorrectMessage()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));
            arena.Enroll(new Warrior("George", 20, 50));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Peter", "InvalidDefender"),
                "There is no fighter with name InvalidDefender enrolled for the fights!");
        }

        [Test]
        public void FightMethod_AttackerAndDefenderInvalid_ThrowsInvalidOperationException()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));
            arena.Enroll(new Warrior("George", 20, 50));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Invalid1", "Invalid2"));
        }

        [Test]
        public void FightMethod_AttackerAndDefenderValid_SuccessfulAttack()
        {
            arena.Enroll(new Warrior("Peter", 20, 50));
            arena.Enroll(new Warrior("George", 20, 50));

            arena.Fight("Peter", "George");

            Assert.AreEqual(30, arena.Warriors.First(w => w.Name == "Peter").HP);
            Assert.AreEqual(30, arena.Warriors.First(w => w.Name == "George").HP);
        }
    }
}
