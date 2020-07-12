using System;
using System.Collections.Generic;

namespace P08CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    int power = int.Parse(tokens[1]);

                    if (!engines.ContainsKey(model))
                    {
                        engines[model] = new Engine(model, power);
                    }
                }
                else if (tokens.Length == 3)
                {
                    string model = tokens[0];
                    int power = int.Parse(tokens[1]);

                    if (Char.IsDigit(tokens[2][0]))
                    {
                        int displacement = int.Parse(tokens[2]);

                        if (!engines.ContainsKey(model))
                        {
                            engines[model] = new Engine(model, power, displacement);
                        }
                    }
                    else
                    {
                        string efficiency = tokens[2];

                        if (!engines.ContainsKey(model))
                        {
                            engines[model] = new Engine(model, power, 0, efficiency);
                        }
                    }
                }
                else
                {
                    string model = tokens[0];
                    int power = int.Parse(tokens[1]);
                    int displacement = int.Parse(tokens[2]);
                    string efficiency = tokens[3];

                    if (!engines.ContainsKey(model))
                    {
                        engines[model] = new Engine(model, power, displacement, efficiency);
                    }
                }

            }

            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string engine = tokens[1];

                    cars.Add(new Car(model, engines[engine]));
                }
                else if (tokens.Length == 3)
                {
                    string model = tokens[0];
                    string engine = tokens[1];

                    if (Char.IsDigit(tokens[2][0]))
                    {
                        int weight = int.Parse(tokens[2]);
                        cars.Add(new Car(model, engines[engine], weight));
                    }
                    else
                    {
                        string color = tokens[2];
                        cars.Add(new Car(model, engines[engine], 0, color));
                    }                  
                }
                else
                {
                    string model = tokens[0];
                    string engine = tokens[1];
                    int weight = int.Parse(tokens[2]);
                    string color = tokens[3];

                    cars.Add(new Car(model, engines[engine], weight, color));
                }
            }

            foreach (var car in cars)
            {
                string model = car.Model;
                Engine engine = car.Engine;
                int weight = car.Weight;
                string color = car.Color;

                Console.WriteLine($"{model}:");
                Console.WriteLine(engine);

                if (weight != 0)
                {
                    Console.WriteLine($"  Weight: {weight}");
                }
                else
                {
                    Console.WriteLine($"  Weight: n/a");
                }

                if (color != null)
                {
                    Console.WriteLine($"  Color: {color}");
                }
                else
                {
                    Console.WriteLine($"  Color: n/a");
                }
            }
        }
    }
}
