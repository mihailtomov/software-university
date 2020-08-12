using System;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitted = command.Split();

                if (splitted[0] == "Switch")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < numbers.Length)
                    {
                        if (numbers[index] < 0)
                        {
                            numbers[index] = numbers[index] * -1;
                        }

                        else
                        {
                            numbers[index] = -numbers[index];
                        }
                    }
                }

                if (splitted[0] == "Change")
                {
                    int index = int.Parse(splitted[1]);
                    int value = int.Parse(splitted[2]);

                    if (index >= 0 && index < numbers.Length)
                    {
                        numbers[index] = value;
                    }
                }

                if (splitted[1] == "Negative")
                {
                    int sumOfNegative = 0;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] < 0)
                        {
                            sumOfNegative += numbers[i];
                        }
                    }

                    Console.WriteLine(sumOfNegative);
                }

                if (splitted[1] == "Positive")
                {
                    int sumOfPositive = 0;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] >= 0)
                        {
                            sumOfPositive += numbers[i];
                        }
                    }

                    Console.WriteLine(sumOfPositive);
                }

                if (splitted[1] == "All")
                {
                    Console.WriteLine(numbers.Sum());
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] >= 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
        }
    }
}
