using System;

namespace P04PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;

        private const int BaseCaloriesPerGram = 2;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;
        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        private string ToppingType 
        { 
            get
            {
                return this.toppingType;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }
        private double Weight 
        { 
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram { get => CalculateCaloriesPerType(); }

        private double CalculateCaloriesPerType()
        {
            switch (this.ToppingType.ToLower())
            {
                case "meat": return (BaseCaloriesPerGram * weight) * MeatModifier;
                case "veggies": return (BaseCaloriesPerGram * weight) * VeggiesModifier;
                case "cheese": return (BaseCaloriesPerGram * weight) * CheeseModifier;
                default: return (BaseCaloriesPerGram * weight) * SauceModifier;
            }
        }
    }
}