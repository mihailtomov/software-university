using P04WildFarm.Models.Animals;
using P04WildFarm.Models.Animals.Birds;

namespace P04WildFarm.Factories
{
    public class BirdFactory : AnimalFactory
    {
        private double wingSize;

        public BirdFactory(string name, double weight, double wingSize) : base(name, weight)
        {
            this.wingSize = wingSize;
        }

        public override Animal CreateAnimal(string type)
        {
            switch (type)
            {
                case "Owl": return new Owl(name, weight, wingSize);
                default: return new Hen(name, weight, wingSize);
            }
        }
    }
}
