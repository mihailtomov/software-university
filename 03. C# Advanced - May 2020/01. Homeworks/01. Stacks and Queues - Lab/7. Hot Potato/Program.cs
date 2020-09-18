using System;
using System.Collections.Generic;
using System.Reflection;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int numberOfTosses = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(input);

            while (kids.Count > 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                    string currKid = kids.Dequeue();
                    kids.Enqueue(currKid);
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }

            Console.WriteLine($"Last is {kids.Peek()}");
        }
    }
}
