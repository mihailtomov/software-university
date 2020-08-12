using P03Raiding.Models;

namespace P03Raiding.Factories
{
    public class PaladinFactory : HeroFactory
    {
        private string name;

        public PaladinFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Paladin(name);
        }
    }
}
