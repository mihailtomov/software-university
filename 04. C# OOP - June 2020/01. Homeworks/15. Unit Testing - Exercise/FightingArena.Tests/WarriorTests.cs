using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Peter", 10, 50);
        }

        [Test]
        public void Constructor_ValidArguments_ShouldInitializeCorrectState()
        {
            Assert.AreEqual("Peter", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(50, warrior.HP);
        }

        [Test]
        public void Constructor_InvalidArgument_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior("George", -5, 35));
        }

        [Test]
        public void NameProperty_ValidData_ShouldSetAndReturnValue()
        {
            string expected = "Peter";
            string actual = warrior.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameProperty_NullEmptyOrWhitespace_ShouldThrowArgumentException
            (string nullEmptyOrWhitespace)
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior(nullEmptyOrWhitespace, 10, 50));
        }

        [Test]
        public void DamageProperty_ValidData_ShouldSetAndReturnValue()
        {
            int expected = 10;
            int actual = warrior.Damage;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DamageProperty_ZeroOrNegativeNumber_ShouldThrowArgumentException
            (int zeroOrNegativeNum)
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior("George", zeroOrNegativeNum, 40));
        }

        [Test]
        public void HP_Property_ValidData_ShouldSetAndReturnValue()
        {
            int expected = 50;
            int actual = warrior.HP;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HP_Property_NegativeNumber_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior("George", 10, -1));
        }

        [TestCase(30)]
        [TestCase(15)]
        public void AttackMethod_AttackerHPEqualOrBelow30_ShouldThrowInvalidOperationException
            (int equalOrBelow30)
        {
            warrior = new Warrior("George", 10, equalOrBelow30);
            Warrior target = new Warrior("Teodor", 20, 40);

            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(target));
        }

        [TestCase(30)]
        [TestCase(15)]
        public void AttackMethod_DefenderHPEqualOrBelow30_ShouldThrowInvalidOperationException
            (int equalOrBelow30)
        {
            Warrior target = new Warrior("Teodor", 20, equalOrBelow30);

            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(target));
        }

        [Test]
        public void AttackMethod_AttackerHPLessThanDefenderDamage_ShouldThrowInvalidOperationException()
        {
            Warrior target = new Warrior("Teodor", 60, 100);

            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(target));
        }

        [Test]
        public void AttackMethod_AttackerTakeDamage_ShouldDecreaseAttackerHPWtihDamage()
        {
            Warrior target = new Warrior("Teodor", 30, 100);

            warrior.Attack(target);

            Assert.AreEqual(20, warrior.HP);
        }

        [Test]
        public void AttackMethod_AttackerDamageBiggerThanDefenderHP_ShouldSetDefenderHPToZero()
        {
            warrior = new Warrior("Peter", 50, 50);
            Warrior target = new Warrior("Teodor", 30, 40);

            warrior.Attack(target);

            Assert.AreEqual(0, target.HP);
        }

        [TestCase(30)]
        [TestCase(40)]
        public void AttackMethod_AttackerDamageLessOrEqualToDefenderHP_ShouldDecreaseDefenderHPWithDamage
            (int lessOrEqualToHP)
        {
            warrior = new Warrior("Peter", lessOrEqualToHP, 50);
            Warrior target = new Warrior("Teodor", 30, 40);
            int expectedHP = target.HP - lessOrEqualToHP;

            warrior.Attack(target);

            Assert.AreEqual(expectedHP, target.HP);
        }
    }
}