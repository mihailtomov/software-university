using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double weightIncrease = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void FeedAnimal(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Weight += weightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
