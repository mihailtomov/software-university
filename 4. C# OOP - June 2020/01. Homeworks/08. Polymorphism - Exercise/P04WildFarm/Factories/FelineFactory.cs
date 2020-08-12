using P04WildFarm.Models.Animals;
using P04WildFarm.Models.Animals.Mammals.Felines;

namespace P04WildFarm.Factories
{
    public class FelineFactory : AnimalFactory
    {
        private string livingRegion;
        private string breed;

        public FelineFactory(string name, double weight, string livingRegion, string breed) : base (name, weight)
        {
            this.livingRegion = livingRegion;
            this.breed = breed;
        }

        public override Animal CreateAnimal(string type)
        {
            switch (type)
            {
                case "Cat": return new Cat(name, weight, livingRegion, breed);
                default: return new Tiger(name, weight, livingRegion, breed);
            }
        }
    }
}
