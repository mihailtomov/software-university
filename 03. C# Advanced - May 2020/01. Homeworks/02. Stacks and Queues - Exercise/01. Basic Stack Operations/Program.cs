using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] threeNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numsToPush = threeNums[0];
            int numsToPop = threeNums[1];
            int numToCheck = threeNums[2];

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count != 0)
            {
                if (stack.Contains(numToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
