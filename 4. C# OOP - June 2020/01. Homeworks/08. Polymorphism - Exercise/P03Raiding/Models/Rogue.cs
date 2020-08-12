namespace P03Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int defaultPower = 80;
        private readonly int power = defaultPower;

        public Rogue(string name)
        {
            Name = name;
        }

        public override string Name { get; protected set; }

        public override int Power => power;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
