using System;
using System.Collections.Generic;
using System.Linq;

namespace P03GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                list.Add(box);
            }

            int[] swapCommand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = swapCommand[0];
            int secondIndex = swapCommand[1];

            SwapIndexes(list, firstIndex, secondIndex);

            foreach (var box in list)
            {
                Console.WriteLine(box);
            }
        }

        static void SwapIndexes<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
