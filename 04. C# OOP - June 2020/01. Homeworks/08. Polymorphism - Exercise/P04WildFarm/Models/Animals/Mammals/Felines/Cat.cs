using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double weightIncrease = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void FeedAnimal(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
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
            return "Meow";
        }
    }
}
