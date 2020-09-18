using P04WildFarm.Models.Foods;

namespace P04WildFarm.Factories
{
    public class FoodFactory : Food
    {
        public FoodFactory(int quantity) : base(quantity)
        {
        }

        public Food CreateFood(string type)
        {
            switch (type)
            {
                case "Vegetable": return new Vegetable(Quantity);
                case "Fruit": return new Fruit(Quantity);
                case "Meat": return new Meat(Quantity);
                default: return new Seeds(Quantity);
            }
        }
    }
}
