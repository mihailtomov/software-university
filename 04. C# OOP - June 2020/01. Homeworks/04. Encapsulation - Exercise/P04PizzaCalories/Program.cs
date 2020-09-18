using System;

namespace P04PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            var pizza = new Pizza("default");

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split();
                string classType = splitArgs[0];

                if (classType == "Pizza")
                {
                    string name = splitArgs[1];

                    try
                    {
                        pizza = new Pizza(name);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
                if (classType == "Dough")
                {
                    string flourType = splitArgs[1];
                    string bakingTechnique = splitArgs[2];
                    double weight = double.Parse(splitArgs[3]);

                    try
                    {
                        var dough = new Dough(flourType, bakingTechnique, weight);
                        pizza.Dough = dough;

                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
                if (classType == "Topping")
                {
                    string toppingType = splitArgs[1];
                    double weight = double.Parse(splitArgs[2]);

                    try
                    {
                        var topping = new Topping(toppingType, weight);

                        try
                        {
                            pizza.AddTopping(topping);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
        }
    }
}
