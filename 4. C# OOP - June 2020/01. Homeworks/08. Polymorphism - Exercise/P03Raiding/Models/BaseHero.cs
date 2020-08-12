namespace P03Raiding
{
    public abstract class BaseHero
    {
        public abstract string Name { get; protected set; }
        public abstract int Power { get; }

        public abstract string CastAbility();
    }
}
