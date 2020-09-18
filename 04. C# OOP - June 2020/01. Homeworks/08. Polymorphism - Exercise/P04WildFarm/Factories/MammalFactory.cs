using P04WildFarm.Models.Animals;
using P04WildFarm.Models.Animals.Mammals;

namespace P04WildFarm.Factories
{
    public class MammalFactory : AnimalFactory
    {
        private string livingRegion;

        public MammalFactory(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.livingRegion = livingRegion;
        }

        public override Animal CreateAnimal(string type)
        {
            switch (type)
            {
                case "Mouse": return new Mouse(name, weight, livingRegion);
                default: return new Dog(name, weight, livingRegion);
            }
        }
    }
}
