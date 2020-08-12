using Moq;
using NUnit.Framework;
using Skeleton;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsExperienceWhenTargetDies()
    {
        Mock<IWeapon> mockedWeapon = new Mock<IWeapon>();
        Mock<ITarget> mockedTarget = new Mock<ITarget>();
        mockedTarget.Setup(t => t.IsDead()).Returns(true);
        mockedTarget.Setup(t => t.GiveExperience()).Returns(5);
        IWeapon weapon = mockedWeapon.Object;
        ITarget target = mockedTarget.Object;
        Hero hero = new Hero("Peter", weapon);

        hero.Attack(target);

        Assert.That(hero.Experience, Is.EqualTo(5));
    }
}