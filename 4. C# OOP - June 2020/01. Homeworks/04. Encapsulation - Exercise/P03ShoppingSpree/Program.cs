using System;
using System.Collections.Generic;
using System.Linq;

namespace P03ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] allPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] allProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < allPeople.Length; i++)
            {
                string person = allPeople[i];
                string[] personArgs = person.Split("=");
                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);

                try
                {
                    people.Add(new Person(name, money));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            for (int i = 0; i < allProducts.Length; i++)
            {
                string product = allProducts[i];
                string[] productArgs = product.Split("=");
                string name = productArgs[0];
                decimal cost = decimal.Parse(productArgs[1]);

                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string command;

            while((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = splitArgs[0];
                string productName = splitArgs[1];

                Person person = people.First(x => x.Name == personName);
                Product product = products.First(x => x.Name == productName);

                if (person.Money >= product.Cost)
                {
                    Console.WriteLine($"{personName} bought {productName}");
                    person.Money -= product.Cost;
                    person.bagOfProducts.Add(product);
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var person in people)
            {
                if (person.bagOfProducts.Count > 0)
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.bagOfProducts)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
