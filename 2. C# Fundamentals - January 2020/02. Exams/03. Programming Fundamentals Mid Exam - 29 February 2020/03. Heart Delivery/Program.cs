using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();
            int startIndex = 0;

            while (command != "Love!")
            {
                string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (splitted[0] == "Jump")
                {
                    int length = int.Parse(splitted[1]);
                    startIndex += length;

                    if (startIndex >= 0 && startIndex < integers.Count)
                    {
                        if (integers[startIndex] == 0)
                        {
                            Console.WriteLine($"Place {startIndex} already had Valentine's day.");
                        }

                        if (integers[startIndex] >= 2)
                        {
                            integers[startIndex] -= 2;

                            if (integers[startIndex] == 0)
                            {
                                Console.WriteLine($"Place {startIndex} has Valentine's day.");
                            }
                        }
                    }

                    if (startIndex > integers.Count - 1)
                    {
                        startIndex = 0;

                        if (integers[startIndex] == 0)
                        {
                            Console.WriteLine($"Place {startIndex} already had Valentine's day.");
                        }

                        if (integers[startIndex] >= 2)
                        {
                            integers[startIndex] -= 2;

                            if (integers[startIndex] == 0)
                            {
                                Console.WriteLine($"Place {startIndex} has Valentine's day.");
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {startIndex}.");

            bool isSuccessful = true;
            int houseCount = 0;

            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] != 0)
                {
                    houseCount++;
                    isSuccessful = false;
                }
            }

            if (isSuccessful == true)
            {
                Console.WriteLine("Mission was successful.");
            }

            else
            {
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}
