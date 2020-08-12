using P04WildFarm.Factories;
using P04WildFarm.Models.Animals;
using P04WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P04WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command;
            int line = 0;
            int index = 0;

            AnimalFactory factory = null;

            while ((command = Console.ReadLine()) != "End")
            {
                if (line % 2 == 0)
                {
                    string[] animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (animalInfo.Length == 5)
                    {
                        string type = animalInfo[0];
                        string name = animalInfo[1];
                        double weight = double.Parse(animalInfo[2]);
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        factory = new FelineFactory(name, weight, livingRegion, breed);

                        if (factory != null)
                        {
                            animals.Add(factory.CreateAnimal(type));
                        }
                    }
                    if (animalInfo.Length == 4)
                    {
                        if (!Char.IsDigit(animalInfo[3][0]))
                        {
                            string type = animalInfo[0];
                            string name = animalInfo[1];
                            double weight = double.Parse(animalInfo[2]);
                            string livingRegion = animalInfo[3];
                            factory = new MammalFactory(name, weight, livingRegion);

                            if (factory != null)
                            {
                                animals.Add(factory.CreateAnimal(type));
                            }
                        }
                        else
                        {
                            string type = animalInfo[0];
                            string name = animalInfo[1];
                            double weight = double.Parse(animalInfo[2]);
                            double wingSize = double.Parse(animalInfo[3]);
                            factory = new BirdFactory(name, weight, wingSize);

                            if (factory != null)
                            {
                                animals.Add(factory.CreateAnimal(type));
                            }
                        }
                    }
                }
                else
                {
                    string[] foodInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string foodType = foodInfo[0];
                    int quantity = int.Parse(foodInfo[1]);
                    Food food = new FoodFactory(quantity).CreateFood(foodType);

                    Console.WriteLine(animals[index].ProduceSound());
                    animals[index].FeedAnimal(food);
                    index++;                   
                }

                line++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
