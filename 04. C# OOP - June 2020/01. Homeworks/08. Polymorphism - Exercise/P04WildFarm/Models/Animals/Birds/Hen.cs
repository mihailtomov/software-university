using P04WildFarm.Models.Foods;

namespace P04WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double weightIncrease = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void FeedAnimal(Food food)
        {
            Weight += weightIncrease * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
