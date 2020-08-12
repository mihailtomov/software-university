using P03Raiding.Models;

namespace P03Raiding.Factories
{
    public class RogueFactory : HeroFactory
    {
        private string name;

        public RogueFactory(string name)
        {
            this.name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Rogue(name);
        }
    }
}
