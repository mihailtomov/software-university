using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Dummy dummy = new Dummy(10, 5);

        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(5)
            , "Dummy does not lose health when attacked");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(5, 5);

        dummy.TakeAttack(5);

        Assert.That(() => dummy.TakeAttack(5), Throws.InvalidOperationException
            , "Dead dummy does not throw exception when attacked");
    }

    [Test]
    public void DeadDummyCanGiveExperience()
    {
        Dummy dummy = new Dummy(0, 5);

        Assert.That(() => dummy.GiveExperience(), Is.EqualTo(5)
            , "Dead dummy does not give experience");
    }

    [Test]
    public void AliveDummyCantGiveExperience()
    {
        Dummy dummy = new Dummy(5, 5);

        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException
            , "Alive dummy gives experience before dying");
    }
}
