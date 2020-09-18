using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double weightIncrease = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
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
            return "Woof!";
        }
    }
}
