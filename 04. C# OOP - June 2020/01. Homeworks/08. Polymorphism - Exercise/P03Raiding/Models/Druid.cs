namespace P03Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int defaultPower = 80;
        private readonly int power = defaultPower;

        public Druid(string name)
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
