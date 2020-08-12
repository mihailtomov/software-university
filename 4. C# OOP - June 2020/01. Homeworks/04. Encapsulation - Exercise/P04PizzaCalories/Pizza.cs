using System;
using System.Collections.Generic;

namespace P04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name 
        { 
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }
        public IReadOnlyCollection<Topping> Toppings { get => this.toppings.AsReadOnly(); }
        public Dough Dough { private get; set; }
        public double TotalCalories { get => GetTotalCalories(); }

        private double GetTotalCalories()
        {
            double totalSum = Dough.CaloriesPerGram;

            foreach (var topping in Toppings)
            {
                totalSum += topping.CaloriesPerGram;
            }

            return totalSum;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
    }
}