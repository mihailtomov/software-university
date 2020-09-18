using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double weightIncrease = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void FeedAnimal(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
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
            return "Squeak";
        }
    }
}
