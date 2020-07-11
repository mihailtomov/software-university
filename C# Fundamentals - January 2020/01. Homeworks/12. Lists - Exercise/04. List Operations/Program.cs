using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitted = command.Split();

                if (splitted[0] == "Add")
                {
                    int number = int.Parse(splitted[1]);
                    numbers.Add(number);
                }

                if (splitted[0] == "Insert")
                {
                    int number = int.Parse(splitted[1]);
                    int index = int.Parse(splitted[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

                if (splitted[0] == "Remove")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

                if (splitted[0] == "Shift")
                {
                    int count = int.Parse(splitted[2]);
                    count = count % numbers.Count;

                    if (splitted[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }

                    if (splitted[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count - 1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
