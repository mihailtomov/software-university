using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            string command;
            int totalPassedCars = 0;

            while((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    if (cars.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalPassedCars++;
                        }
                    }
                    else
                    {
                        int count = cars.Count;

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalPassedCars++;
                        }
                    }
                }
            }

            Console.WriteLine($"{totalPassedCars} cars passed the crossroads.");
        }
    }
}
