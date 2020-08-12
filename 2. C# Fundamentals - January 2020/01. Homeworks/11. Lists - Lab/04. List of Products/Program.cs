using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> productsList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();
                productsList.Add(product);
            }

            productsList.Sort();

            int currentNum = 1;

            for (int i = 0; i < productsList.Count; i++)
            {
                Console.WriteLine($"{currentNum}.{productsList[i]}");
                currentNum++;
            }
        }
    }
}
