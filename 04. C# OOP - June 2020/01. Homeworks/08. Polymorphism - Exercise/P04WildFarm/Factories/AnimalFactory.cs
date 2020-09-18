using P04WildFarm.Models.Animals;

namespace P04WildFarm.Factories
{
    public abstract class AnimalFactory
    {
        protected string name;
        protected double weight;

        protected AnimalFactory(string name, double weight)
        {
            this.name = name;
            this.weight = weight;
        }

        public abstract Animal CreateAnimal(string type);
    }
}
