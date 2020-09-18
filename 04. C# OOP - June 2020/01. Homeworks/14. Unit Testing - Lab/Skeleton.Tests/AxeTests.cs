using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Dummy target;

    [SetUp]
    public void SetUp()
    {
        target = new Dummy(10, 10);
    }
    [Test]
    public void WeaponLosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(5, 10);

        axe.Attack(target);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9)
            , "Weapon does not lose durability after attack");
    }

    [Test]
    public void BrokenWeaponThrowsException()
    {
        Axe axe = new Axe(3, 1);

        axe.Attack(target);

        Assert.That(() => axe.Attack(target), Throws.InvalidOperationException
            , "Broken weapon does not throw exception");
    }
}