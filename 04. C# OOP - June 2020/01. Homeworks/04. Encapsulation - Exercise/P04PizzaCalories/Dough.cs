using System;

namespace P04PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        private const int BaseCaloriesPerGram = 2;
        private const double WhiteModifier = 1.5;
        private const double WholegrainModifier = 1.0;
        private const double CrispyModifier = 0.9;
        private const double ChewyModifier = 1.1;
        private const double HomemadeModifier = 1.0;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string FlourType 
        { 
            get
            {
                return this.flourType;
            }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value.ToLower();
            }
        }
        private string BakingTechnique 
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value.ToLower();
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }
        public double CaloriesPerGram { get => CalculateCaloriesPerType(); }

        private double CalculateCaloriesPerType()
        {
            if (this.FlourType == "white")
            {
                switch (this.BakingTechnique)
                {
                    case "crispy": return (BaseCaloriesPerGram * weight) * WhiteModifier * CrispyModifier;
                    case "chewy": return (BaseCaloriesPerGram * weight) * WhiteModifier * ChewyModifier;
                    default: return (BaseCaloriesPerGram * weight) * WhiteModifier * HomemadeModifier;
                }
            }
            else
            {
                switch (this.BakingTechnique)
                {
                    case "crispy": return (BaseCaloriesPerGram * weight) * WholegrainModifier * CrispyModifier;
                    case "chewy": return (BaseCaloriesPerGram * weight) * WholegrainModifier * ChewyModifier;
                    default: return (BaseCaloriesPerGram * weight) * WholegrainModifier * HomemadeModifier;
                }
            }
        }
    }
}