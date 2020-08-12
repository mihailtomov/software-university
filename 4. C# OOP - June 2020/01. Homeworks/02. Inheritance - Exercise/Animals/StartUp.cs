using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (age < 0 || (gender != "Male" && gender != "Female"))
                {
                    Console.WriteLine("Invalid input!");
                }
                if (age >= 0 && (gender == "Male" || gender == "Female"))
                {
                    if (animalType == "Dog")
                    {
                        animals.Add(new Dog(name, age, gender));
                    }
                    if (animalType == "Cat")
                    {
                        animals.Add(new Cat(name, age, gender));
                    }
                    if (animalType == "Frog")
                    {
                        animals.Add(new Frog(name, age, gender));
                    }
                    if (animalType == "Kitten")
                    {
                        animals.Add(new Kitten(name, age));
                    }
                    if (animalType == "Tomcat")
                    {
                        animals.Add(new Tomcat(name, age));
                    }
                }             
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
