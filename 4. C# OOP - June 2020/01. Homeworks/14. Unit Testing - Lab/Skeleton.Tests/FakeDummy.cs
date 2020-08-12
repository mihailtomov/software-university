namespace Skeleton.Tests
{
    public class FakeDummy : ITarget
    {
        public int Health => 0;

        public int GiveExperience()
        {
            return 5;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            
        }
    }
}
