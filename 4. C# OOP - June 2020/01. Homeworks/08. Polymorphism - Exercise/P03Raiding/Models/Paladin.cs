namespace P03Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int defaultPower = 100;
        private readonly int power = defaultPower;

        public Paladin(string name)
        {
            Name = name;
        }

        public override string Name { get; protected set; }

        public override int Power => power;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
