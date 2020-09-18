namespace P03Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int defaultPower = 100;
        private readonly int power = defaultPower;

        public Warrior(string name)
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
