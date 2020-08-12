using P03Raiding.Models;

namespace P03Raiding.Factories
{
    public class DruidFactory : HeroFactory
    {
        private string name;

        public DruidFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Druid(name);
        }
    }
}
