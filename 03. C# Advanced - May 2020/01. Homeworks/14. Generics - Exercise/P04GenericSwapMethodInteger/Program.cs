using System;
using System.Collections.Generic;
using System.Linq;

namespace P04GenericSwapMethodInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> list = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
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
